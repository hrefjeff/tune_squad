using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Security.AccessControl;
using System.Collections;
/*
 * Class Name:UserList
 * Author: Jordan Beck
 * Date: 4/2/2015
 * Modified by: Jordan Beck
 * This class creates, stores, and maintains usernames, passwords, admin status, and attempts 
 * of invalid log on attempts.
 * ------------------------------------------
 * List of public functions and their jobs
 * UserList()
 * Creates the text file that will store the usernames, and etc.
 * 
 * AddUser(string username, string password, bool admin)
 * Creates a new user in the following format: 
 * John Password 0 0
 * The first 0  represents admin status, the second represents the login attempts.
 * 
 * IsUser(string username)
 * Returns a boolean value if the user is entered into the text file already.
 * 
 * ChangePassword(string username, string password)
 * Edits the text file to change the users password.
 * 
 * TestPassword(string username, string tryPassword)
 * Searches the text file for the user, and attempts to validate the password.
 * If the password is wrong it increments the log on attempts
 * If it is correct it resets the attempts to zero.
 * returns a bool for if the password was correct or not.
 * 
 * DelUser(string username)
 * Searches the text file for the user and removes them.
 * 
 * IsAdmin(string username)
 * Returns a bool if the user provided is an admin or not.
 */
public class UserList
{
    string ioFile = "Username2.txt";

    public UserList()
    {
        //Opens or creates file
        FileStream file = new FileStream(@ioFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        file.Close();
    }


    public void AddUser(string userName, string password, bool admin)
    {
        //Test to see if username is taken.
        if (IsUser(userName))
        {
            return;
        }

        //This block creates the line to input into the file.
        string line = "";
        line = userName;
        line = line + " ";
        line = line + password;
        line = line + " ";
        if (admin)
        {
            line = line + "1";
        }
        else
        {
            line = line + "0";
        }

        //Adds the field for number of attempts.
        line = line + " 0";

        //Inputs the User to Document.
        using (StreamWriter writeFile = File.AppendText(@ioFile))
        {
            writeFile.WriteLine(line);
            writeFile.Close();
            AddEncryption(@ioFile);
        }
    }
    public bool IsUser(string userName)
    {
        string testName = "";
        using (StreamReader reader = new StreamReader(@ioFile))
        {
            RemoveEncryption(@ioFile);
            string line;
            // Block compares username
            while ((line = reader.ReadLine()) != null)
            {
                int i = 0;
                testName = "";
                if (!String.IsNullOrEmpty(line))
                {
                    //Gets Name
                    while (!((line[i] == ' ') || (line[i] == '\n')))
                    {
                        testName = testName + line[i];
                        i++;
                    }

                    if (testName == userName)
                    {
                        reader.Close();
                        return true;
                    }
                }
            }
            reader.Close();
        }
        return false;
    }
    public void ChangePassword(string inputName, string inputPassword)
    {
        string actualName = inputName;
        inputName = inputName + " ";
        using (StreamReader reader = new StreamReader(@ioFile))
        {
            RemoveEncryption(@ioFile);
            string line = "";
            int i = 0;
            int row = 0;
            while ((line = reader.ReadLine()) != null)
            {
                row++;
                while (line[i] == inputName[i])
                {
                    if (line[i] == ' ')
                    {
                        reader.Close();
                        ChangeFilePassword(actualName, inputPassword);
                        return;
                    }
                    i++;
                }
            }
        }
    }
    public bool TestPassword(string inputName, string inputPassword)
    {
        char attemptsAllowed = '4';
        bool isCorrect = false;
        string input = inputName + " " + inputPassword + " ";
        int row = 0;
        using (StreamReader reader = new StreamReader(@ioFile))
        {
            RemoveEncryption(@ioFile);
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                int i = 0;
                row++;
                if (line[i] == input[i])
                {
                    do
                    {
                        i++;
                        if ((line[i] == input[i]) && (line[i] == ' '))
                        {
                            do
                            {
                                i++;
                                if ((line[i] == input[i]) && (line[i] == ' '))
                                {
                                    //Doesn't Allow for over 4 attempts
                                    //i+3 is displacement for the the Attempts
                                    if (line[i + 3] == attemptsAllowed)
                                    {
                                        return false;
                                    }
                                    else
                                    {
                                        reader.Close();
                                        ResetAttemptTry(row, i + 3);
                                    }

                                    isCorrect = true;
                                    return isCorrect;
                                }
                                if (line[i] != input[i])
                                {
                                    while (line[i] != ' ')
                                    {
                                        i++;
                                    }
                                    reader.Close();
                                    IncreaseAttemptTry(row, i + 3);
                                    return isCorrect;
                                }
                            } while (line[i] == input[i]);

                        }
                    } while (line[i] == input[i]);
                }
            }
            reader.Close();
        }
        return isCorrect;
    }
    public void DelUser(string inputName)
    {
        inputName = inputName + " ";
        using (StreamReader reader = new StreamReader(@ioFile))
        {
            RemoveEncryption(@ioFile);
            string line = "";
            int row = 0;
            while ((line = reader.ReadLine()) != null)
            {
                int i = 0;
                row++;
                if (!String.IsNullOrEmpty(line))
                {
                    if (line[i] == inputName[i])
                    {
                        //Validates it has the correct user
                        do
                        {
                            i++;
                            if (line[i] == ' ')
                            {
                                //removes line by rewriting the Username file
                                reader.Close();
                                ReWriteFile(row);
                                return;
                            }
                        } while ((line[i] == inputName[i]) && (line[i] != ' '));
                    }
                }
            }
            reader.Close();
        }
    }

    public ArrayList GetUserNames()
    {
        ArrayList usernameList = new ArrayList();
        using (StreamReader reader = new StreamReader(@ioFile))
        {

            RemoveEncryption(@ioFile);
            string line;
            // Block compares username
            while ((line = reader.ReadLine()) != null)
            {
                int i = 0;
                string testName = "";
                if (!String.IsNullOrEmpty(line))
                {
                    //Gets Name
                    while (!((line[i] == ' ') || (line[i] == '\n')))
                    {
                        testName = testName + line[i];
                        i++;
                    }
                    usernameList.Add(testName);
                }
            }
        }


        return usernameList;
    }
    public bool IsAdmin(string inputName)
    {
        using (StreamReader reader = new StreamReader(@ioFile))
        {
            RemoveEncryption(@ioFile);
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                int i = 0;

                if ((!String.IsNullOrEmpty(line)) && (line[i] == inputName[i]))
                {
                    do
                    {
                        i++;
                        if (line[i] == ' ')
                        {
                            //Block skips the password
                            do
                            {
                                i++;
                            } while (!(line[i] == ' '));
                            //
                            //i+1 is displacement for the admin
                            if (line[i + 1] == '0')
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    } while (line[i] == inputName[i]);
                }
            }
            reader.Close();
        }
        return false;
    }


    private void ReWriteFile(int rowRemove)
    {
        string fileToWrite = "";
        //Reads through the file and creates a new file
        using (StreamReader reader = new StreamReader(@ioFile))
        {
            RemoveEncryption(@ioFile);
            string line = "";
            int row = 0;
            while ((line = reader.ReadLine()) != null)
            {
                row++;
                if (row != rowRemove)
                {
                    fileToWrite = fileToWrite + line;
                    fileToWrite = fileToWrite + '\n';
                }
            }
            reader.Close();
        }
        //Del file
        File.Delete(@ioFile);
        //recreate file
        FileStream file = new FileStream(@ioFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        file.Close();
        //writes fileToWrite to file
        using (StreamWriter writeFile = File.AppendText(@ioFile))
        {
            writeFile.Write(fileToWrite);
            writeFile.Close();
            AddEncryption(@ioFile);
        }
    }
    private void IncreaseAttemptTry(int rowRemove, int colRemove)
    {
        int attemptsAllowed = 4;
        string fileToWrite = "";
        //Reads through the file and creates a new file
        using (StreamReader reader = new StreamReader(@ioFile))
        {
            RemoveEncryption(@ioFile);
            string line = "";
            int row = 0;
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                row++;
                if (row != rowRemove)
                {
                    fileToWrite = fileToWrite + line;
                }
                else
                {
                    while (i != colRemove)
                    {
                        fileToWrite = fileToWrite + line[i];
                        i++;
                    }
                    if (i == colRemove)
                    {
                        int temp = (int)Char.GetNumericValue(line[i]);
                        temp = temp + 1;
                        if (temp > (attemptsAllowed - 1))
                        {
                            temp = attemptsAllowed;
                        }
                        fileToWrite = fileToWrite + temp.ToString();
                    }
                }
                fileToWrite = fileToWrite + '\n';
            }
            reader.Close();
        }
        //Del file
        File.Delete(@ioFile);
        //recreate file
        FileStream file = new FileStream(@ioFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        file.Close();
        //write fileToWrite to file
        using (StreamWriter writeFile = File.AppendText(@ioFile))
        {
            writeFile.Write(fileToWrite);
            writeFile.Close();
            AddEncryption(@ioFile);
        }
    }
    private void ResetAttemptTry(int rowRemove, int colRemove)
    {
        string fileToWrite = "";
        //Reads through the file and creates a new file
        using (StreamReader reader = new StreamReader(@ioFile))
        {
            RemoveEncryption(@ioFile);
            string line = "";
            int row = 0;
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                row++;

                if (row != rowRemove)
                {
                    fileToWrite = fileToWrite + line;
                }
                else
                {
                    while (i != colRemove)
                    {
                        fileToWrite = fileToWrite + line[i];
                        i++;
                    }
                    if (i == colRemove)
                    {
                        fileToWrite = fileToWrite + "0";
                    }
                }
                fileToWrite = fileToWrite + '\n';
            }
            reader.Close();
        }
        //Del file
        File.Delete(@ioFile);
        //recreate file
        FileStream file = new FileStream(@ioFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        file.Close();
        //write fileToWrite to file
        using (StreamWriter writeFile = File.AppendText(@ioFile))
        {
            writeFile.Write(fileToWrite);
            writeFile.Close();
            AddEncryption(@ioFile);
        }
    }
    private void ChangeFilePassword(string username, string newPassword)
    {
        bool admin = IsAdmin(username);
        DelUser(username);
        AddUser(username, newPassword, admin);
    }

    public static void AddEncryption(string FileName)
    {
        //encrypt here
    }
    // Decrypt a file. 
    public static void RemoveEncryption(string FileName)
    {
        //File.Decrypt(FileName);
    }

    //NOT MY CODE
    //
    /////////////////////////////////////////////////////////////////////////////////////////////
    /*
    static readonly string PasswordHash = "P@@Sw0rd";
    static readonly string SaltKey = "S@LT&KEY";
    static readonly string VIKey = "@1B2c3D4e5F6g7H8";

    public static string Encrypt(string plainText)
		{
			byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

			byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
			var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
			var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
			
			byte[] cipherTextBytes;

			using (var memoryStream = new MemoryStream())
			{
				using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
				{
					cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
					cryptoStream.FlushFinalBlock();
					cipherTextBytes = memoryStream.ToArray();
					cryptoStream.Close();
				}
				memoryStream.Close();
			}
			return Convert.ToBase64String(cipherTextBytes);
		}
    public static string Decrypt(string encryptedText)
		{
			byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
			byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
			var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

			var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
			var memoryStream = new MemoryStream(cipherTextBytes);
			var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
			byte[] plainTextBytes = new byte[cipherTextBytes.Length];

			int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
			memoryStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
		}
    
    static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key,
                                                                byte[] IV)
    {
        // Check arguments. 
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException("Key");
        byte[] encrypted;
        // Create an Aes object 
        // with the specified key and IV. 
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            // Create a decrytor to perform the stream transform.
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key
                                                                , aesAlg.IV);

            // Create the streams used for encryption. 
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt
                                        , encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {

                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
        }
        // Return the encrypted bytes from the memory stream. 
        return encrypted;
    }

    static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key
, byte[] IV)
    {
        // Check arguments. 
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("cipherText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException("Key");

        // Declare the string used to hold 
        // the decrypted text. 
        string plaintext = null;

        // Create an Aes object 
        // with the specified key and IV. 
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            // Create a decrytor to perform the stream transform.
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key
, aesAlg.IV);

            // Create the streams used for decryption. 
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt
, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(
csDecrypt))
                    {

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            return plaintext;

        }
    }

    */


}
