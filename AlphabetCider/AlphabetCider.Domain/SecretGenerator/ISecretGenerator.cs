using System;
using System.Collections.Generic;
using System.Text;

namespace AlphabetCider.Domain.SecretGenerator
{
    public interface ISecretGenerator
    {
        string GenerateSecret(string secret, int messageLength);
    }
}
