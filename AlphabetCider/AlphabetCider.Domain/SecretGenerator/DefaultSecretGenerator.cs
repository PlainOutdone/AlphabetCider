using System;
using System.Collections.Generic;
using System.Text;

namespace AlphabetCider.Domain.SecretGenerator
{
    public class DefaultSecretGenerator : ISecretGenerator
    {
        public string GenerateSecret(string secret, int messageLength)
        {
            if (string.IsNullOrEmpty(secret)) { throw new ArgumentNullException("secret"); }
            if (messageLength <= 0) { throw new ArgumentOutOfRangeException("messageLength"); }

            if (messageLength < secret.Length) { return TruncateSecret(secret, messageLength);  }
            if (messageLength > secret.Length) { return DuplicateSecretThenTruncate(secret, messageLength); }
            return secret;
        }

        private string TruncateSecret(string secret, int messageLength) {
            return secret.Substring(0,messageLength);
        }

        private string DuplicateSecretThenTruncate(string secret, int messageLength)
        {
            var dupedSecret = secret;
            while (dupedSecret.Length < messageLength){ dupedSecret = dupedSecret + dupedSecret; }
            return TruncateSecret(dupedSecret, messageLength);
        }

    }
}
