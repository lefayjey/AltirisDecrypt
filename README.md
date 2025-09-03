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
AltirisDecrypt "SGVsbG8gV29ybGQh..." "MDEyMzQ1Njc4OUFCQw=="
```

## Context

This tool is modeled after the process described in [Checking for Symantec Account Connectivity Credentials (ACCs) - PrivEscCheck](https://itm4n.github.io/checking-symantec-account-credentials-privesccheck/) by itm4n, which details methods for identifying and decrypting Symantec credentials during security assessments. The article demonstrates the exploitation potential of mismanaged or exposed account credentials.[^1]

## License

This script is released for educational and research purposes only.

***

Refer to the linked article above for further technical background on the context and relevant attack scenarios.[^1]
<span style="display:none">[^2]</span>

<div style="text-align: center">⁂</div>

[^1]: https://itm4n.github.io/checking-symantec-account-credentials-privesccheck/

[^2]: https://itm4n.github.io/offline-extraction-of-symantec-account-connectivity-credentials/

