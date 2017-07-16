using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using UserRegistrationAndLoginDemo.Common.Helpers;
using UserRegistrationAndLoginDemo.DTO;

namespace UserRegistrationAndLoginDemo.Common.Security
{
    public class SecurityManager
    {
        const int TOKEN_EXPIRATION_IN_MINUTES = 60;

        static IJwtAlgorithm _algorithm;
        static IJsonSerializer _serializer;
        static IBase64UrlEncoder _urlEncoder;
        static IJwtEncoder _encoder;
        static IDateTimeProvider _provider;
        static IJwtValidator _validator;
        static IJwtDecoder _decoder;

        static SecurityManager()
        {
            _algorithm = new HMACSHA256Algorithm();
            _serializer = new JsonNetSerializer();
            _urlEncoder = new JwtBase64UrlEncoder();            
            _provider = new UtcDateTimeProvider();
            _validator = new JwtValidator(_serializer, _provider);            
        }

        public static string GenerateToken(string jwtSecretKey, UserCredentialDto userData)
        {
            var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var expiry = Math.Round((DateTime.UtcNow.AddMinutes(TOKEN_EXPIRATION_IN_MINUTES) - unixEpoch).TotalSeconds);
            var issuedAt = Math.Round((DateTime.UtcNow - unixEpoch).TotalSeconds);
            //var notBefore = Math.Round((DateTime.UtcNow.AddMonths(6) - unixEpoch).TotalSeconds);

            var payLoad = new Dictionary<string, object>
            {
                { "userid", userData.Id },
                { "sub", userData.UserName },
                { "nbf", issuedAt },
                { "iat", issuedAt },
                { "exp", expiry }
            };
            _encoder = new JwtEncoder(_algorithm, _serializer, _urlEncoder);
            var token = _encoder.Encode(payLoad, jwtSecretKey);
            return token;
        }

        public static ValidatePasswordModel HashPassword(string password, int saltSize)
        {
            var validatePasswordModel = new ValidatePasswordModel();
            validatePasswordModel.Salt = GetRandomSalt(saltSize);
            validatePasswordModel.HashedPassword = BCrypt.Net.BCrypt.HashPassword(password, validatePasswordModel.Salt);
            return validatePasswordModel;
        }

        public static ValidatePasswordModel HashPassword(string password, string salt)
        {
            var validatePasswordModel = new ValidatePasswordModel
            {
                HashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt)
            };
            return validatePasswordModel;
        }

        public static bool IsTokenValid(string token, string jwtSecretKey, bool checkExpiration = true)
        {
            var result = false;
            _decoder = new JwtDecoder(_serializer, _validator, _urlEncoder);
            var payloadJson = _decoder.Decode(token, jwtSecretKey, checkExpiration);
            var payloadData = JsonHelper.Deserialize<Dictionary<string, object>>(payloadJson);

            object expiryTime;

            if (payloadData != null)
            {
                if (checkExpiration)
                {
                    if (payloadData.TryGetValue("exp", out expiryTime))
                    {
                        var unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        var validTo = unixEpoch.AddSeconds(long.Parse(expiryTime.ToString()));

                        if (DateTime.Compare(validTo, DateTime.UtcNow) <= 0)
                            result = false;
                        else
                            result = true;
                    }
                }
            }

            return result;
        }

        public static bool ValidatePassword(string password, string correctHash) =>
            BCrypt.Net.BCrypt.Verify(password, correctHash);

        static string GetRandomSalt(int saltSize) =>
            BCrypt.Net.BCrypt.GenerateSalt(saltSize);
    }
}
