using Fabric.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabric_Sample.Samples.Common
{
    /*
     * Encrypter is a simple string encryption and decryption class.
     * It uses a data hash in SHA512 format combined with an AES algorithm.
     */
    internal class EncrypterSample
    {

        public EncrypterSample() { }

        /*
         * Encrypts a character string and returns its value in encrypted form.
         */
        public void Encrypt()
        {
            Encrypter encrypter = new Encrypter();
            string crypted = encrypter.EncryptValue("String to encrypt.");
        }

        /*
         * Decrypts an encrypted string and returns its value in decrypted form
         */
        public void Decrypt()
        {
            Encrypter encrypter = new Encrypter();
            string decrypted = encrypter.DecryptValue("String to decrypt.");
        }

        /*
         * Encrypts a character string and returns its value in encrypted form.
         * In this example, the call to the encryption method is a static call, so it is unnecessary
         * to instantiate its class.
         */
        public void EncryptStatic()
        {
            string crypted = Encrypter.Encrypt("String to encrypt.");
        }

        /*
         * Encrypts a character string and returns its value in encrypted form.
         * In this example, the call to the encryption method is a static call, so it is unnecessary
         * to instantiate its class.
         * The password used is not the one defined in standard but defined in the method call.
         */
        public void EncryptWithPWDStatic()
        {
            string crypted = Encrypter.Encrypt("String to encrypt.", "P455W0Rd.");
        }

        /*
         * Decrypts a character string and returns its value in Decrypted form.
         * In this example, the call to the decrypt method is a static call, so it is unnecessary
         * to instantiate its class.
         */
        public void DecryptStatic()
        {
            string decrypted = Encrypter.Decrypt("String to decrypt.");
        }

        /*
         * Decrypts a character string and returns its value in Decrypted form.
         * In this example, the call to the decrypt method is a static call, so it is unnecessary
         * to instantiate its class.
         * The password used is not the one defined in standard but defined in the method call.
         */
        public void DecryptWithPWDStatic()
        {
            string decrypted = Encrypter.Decrypt("String to decrypt.", "P455W0Rd.");
        }


    }
}
