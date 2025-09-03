# AltirisDecrypt

A C# utility for offline decrypting Altiris/Symantec Account Connectivity Credentials (ACCs) from base64-encrypted blobs, as found in enterprise environments. The tool extracts the IV and ciphertext from the Altiris data format and uses an AES key to reveal the original plaintext.

## Usage

```
AltirisDecrypt <Base64InputData> <Base64Key>
```

- `<Base64InputData>`: The base64 string containing the encrypted data blob, typically as found in Altiris/Symantec environments.
- `<Base64Key>`: The base64 string representing the decryption key present in the Notification Server's key file.

Example:

```
AltirisDecrypt "AwBcxiEuzG5L1KCP8VnpwJKd/FkxTo1w/G6zKuW7/2CSWcDeB0kxhT20I1x0kQ0+zfKpqNKDZ7YoYD3wKBScPkCiUYBB6HmV2h+Y2Yq5GRnPtLt4I9SfqPnyjzB51p+nITG31FbtxFR38BG2+T0gWbIfrnkZjyQLzTC8trZgjFQqddd85q1eLO4pCj++9Qpr3ZjOxkvaQlQknFbrWXiYGdVY" "+us3+eX22qtRmFThHxiXKSFY1kxDFx0esu+ly5y3NrA="
```

## Context

This tool is modeled after the process described in [Checking for Symantec Account Connectivity Credentials (ACCs) - PrivEscCheck](https://itm4n.github.io/checking-symantec-account-credentials-privesccheck/) by itm4n, which details methods for identifying and decrypting Symantec credentials during security assessments. The article demonstrates the exploitation potential of mismanaged or exposed account credentials. [^1][^2]

## License

This script is released for educational and research purposes only.

***

[^1]: https://itm4n.github.io/checking-symantec-account-credentials-privesccheck/

[^2]: https://itm4n.github.io/offline-extraction-of-symantec-account-connectivity-credentials/

