using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Security.AccessControl;
using System.Collections;
namespace LIFES.Authentication
{
    /*
     * Class Name:UserList
     * Author: Jordan Beck
     * Date: 4/2/2015
     * Modified by: Jordan Beck
     * This class creates, stores, and maintains usernames, passwords,
     *  admin status, and attempts of invalid log on attempts.
     * 
     * Format:
     * John Password 1 2
     * 
     * User is John.
     * Password is Password.
     * Is an Admin.
     * Has attempted his password wrong twice.
     */
    public class UserList
    {
        //string path = Application.StartupPath + "/Username";
        //string ioFile = path;
        string ioFile = "Username2.txt";

        /*
         * Method: UserList
         * Parameters: None
         * Created By: Jordan Beck
         * Date: 4/2/2015
         * Modified By: Jordan Beck
         * 
         * Description: Creates the text file that will store the usernames, and etc.
         */
        public UserList()
        {
            //Opens or creates file
            FileStream file = new FileStream(@ioFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            file.Close();
            //Default Admin used for adding the first admin.
            AddUser("AlanTuring", "06231912", true);
            //We dont want the default to fit the standard
            //Makes it more complicated to in a brute force attempt.
        }

        /*
         * Method: AddUser
         * Parameters: string userName, string password, bool admin
         * Created By: Jordan Beck
         * Date: 4/2/2015
         * Modified By: Jordan Beck
         * 
         * Description: Creates a new user in the following format: 
         * John Password 0 0
         * The first 0  represents admin status,
         *  the second represents the login attempts.
         */
        public bool AddUser(string userName, string password, bool admin)
        {
            //Test to see if username is taken.
            if (IsUser(userName))
            {
                return false;
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
            int j = 0;

            //Inputs the User to Document.
            RemoveEncryption(@ioFile);
            using (StreamWriter writeFile = File.AppendText(@ioFile))
            {
                line = line + '\n';
                writeFile.WriteLine(line);
                writeFile.Close();
            }
            AddEncryption(@ioFile);
            return true;
        }

        /*
         * Method: IsUser
         * Parameters: string userName
         * Created By: Jordan Beck
         * Date: 4/2/2015
         * Modified By: Jordan Beck
         * 
         * Description: Returns a boolean value if the user 
         *  is entered into the text file already.
         */
        public bool IsUser(string userName)
        {
            string testName = "";
            RemoveEncryption(@ioFile);
            using (StreamReader reader = new StreamReader(@ioFile))
            {
                string line;
                // Block compares username
                
                while ((line = reader.ReadLine()) != null)
                {
                    int i = 0;
                    testName = "";
                    if (!(line == ""))
                    {
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
                                AddEncryption(@ioFile);
                                return true;
                            }
                        }
                    }
                }
                reader.Close();
            }
            AddEncryption(@ioFile);
            return false;
        }
        /*
         * Method: ChangePassword
         * Parameters: string userName, string password
         * Created By: Jordan Beck
         * Date: 4/2/2015
         * Modified By: Jordan Beck
         * 
         * Description: Edits the text file to change the users password.
         */
        public bool ChangePassword(string inputName, string inputPassword)
        {
            string actualName = inputName;
            inputName = inputName + " ";
            RemoveEncryption(@ioFile);
            using (StreamReader reader = new StreamReader(@ioFile))
            {
                string line = "";
                int i = 0;
                int row = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    row++;
                    if (line != "")
                    {
                        while (line[i] == inputName[i])
                        {
                            if (line[i] == ' ')
                            {
                                reader.Close();
                                AddEncryption(@ioFile);
                                ChangeFilePassword(actualName, inputPassword);
                                return true;
                            }
                            i++;
                        }
                    }
                }
                reader.Close();
            }
            AddEncryption(@ioFile);
            return false;
        }
        /*
         * Method: TestPassword
         * Parameters: string userName, string tryPassword
         * Created By: Jordan Beck
         * Date: 4/2/2015
         * Modified By: Jordan Beck
         * 
         * Description: Searches the text file for the user, and attempts 
         *  to validate the password.
         * If the password is wrong it increments the log on attempts.
         * If it is correct it resets the attempts to zero.
         * Returns a bool for if the password was correct or not.
         */
        public bool TestPassword(string inputName, string inputPassword)
        {
            char attemptsAllowed = '4';
            bool isCorrect = false;
            string input = inputName + " " + inputPassword + " ";
            int row = 0;

            RemoveEncryption(@ioFile);
            using (StreamReader reader = new StreamReader(@ioFile))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    int i = 0;
                    row++;
                    if (line != "")
                    {
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
                                                reader.Close();
                                                AddEncryption(@ioFile);
                                                return false;
                                            }
                                            else
                                            {
                                                reader.Close();
                                                AddEncryption(@ioFile);
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
                                            AddEncryption(@ioFile);
                                            IncreaseAttemptTry(row, i + 3);
                                            return isCorrect;
                                        }
                                    } while (line[i] == input[i]);

                                }
                            } while (line[i] == input[i]);
                        }
                    }
                }
                reader.Close();
            }
            AddEncryption(@ioFile);
            return isCorrect;
        }
        /*
         * Method: DelUser
         * Parameters: string inputName
         * Created By: Jordan Beck
         * Date: 4/2/2015
         * Modified By: Jordan Beck
         * 
         * Description: Searches the text file for the user and removes them.
         */
        public void DelUser(string inputName)
        {
            inputName = inputName + " ";
            RemoveEncryption(@ioFile);
            using (StreamReader reader = new StreamReader(@ioFile))
            {
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
                                    AddEncryption(@ioFile);
                                    ReWriteFile(row);
                                    return;
                                }
                            } while ((line[i] == inputName[i]) && (line[i] != ' '));
                        }
                    }
                }
                reader.Close();
                AddEncryption(@ioFile);
                return;
            }
        }

        /*
         * Method: GetUserNames
         * Parameters: None
         * Created By: Jordan Beck
         * Date: 4/13/2015
         * Modified By: Jordan Beck
         * 
         * Description: Returns an array of the usernames.
         */
        public ArrayList GetUserNames()
        {
            ArrayList usernameList = new ArrayList();
            RemoveEncryption(@ioFile);
            using (StreamReader reader = new StreamReader(@ioFile))
            {
                string line;
                // Block compares username
                while ((line = reader.ReadLine()) != null)
                {
                    int i = 0;
                    string testName = "";

                    //Skips default Admin
                    if (line == "AlanTuring 06231912 1 0")
                    {
                        //Skips
                    }
                    else if (!String.IsNullOrEmpty(line))
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
                reader.Close();
            }
            AddEncryption(@ioFile);
            return usernameList;
        }

        /*
         * Method: IsAdmin
         * Parameters: string inputName
         * Created By: Jordan Beck
         * Date: 4/2/2015
         * Modified By: Jordan Beck
         * 
         * Description: Returns a bool if the user provided is an admin or not.
         */
        public bool IsAdmin(string inputName)
        {
            RemoveEncryption(@ioFile);
            using (StreamReader reader = new StreamReader(@ioFile))
            {
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
                                    reader.Close();
                                    AddEncryption(@ioFile);
                                    return false;
                                }
                                else
                                {
                                    reader.Close();
                                    AddEncryption(@ioFile);
                                    return true;
                                }
                            }
                        } while (line[i] == inputName[i]);
                    }
                }
                reader.Close();
            }
            AddEncryption(@ioFile);
            return false;
        }

        /*
         * Method: ReWriteFile
         * Parameters: int rowRemove
         * Created By: Jordan Beck
         * Date: 4/2/2015
         * Modified By: Jordan Beck
         * 
         * Description: Rewrites the UserName file
         */
        private void ReWriteFile(int rowRemove)
        {
            string fileToWrite = "";
            //Reads through the file and creates a new file
            RemoveEncryption(@ioFile);
            using (StreamReader reader = new StreamReader(@ioFile))
            {
                string line = "";
                int row = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    row++;
                    if (line != "")
                    {
                        if (row != rowRemove)
                        {
                            fileToWrite = fileToWrite + line;
                            fileToWrite = fileToWrite + '\n';
                        }
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
            }
            AddEncryption(@ioFile);
        }

        /*
         * Method: IncreaseAttemptTry
         * Parameters: int rowRemove, int colRemove
         * Created By: Jordan Beck
         * Date: 4/4/2015
         * Modified By: Jordan Beck
         * 
         * Description: Increases the attempts allowed for the password attempts.
         */
        private void IncreaseAttemptTry(int rowRemove, int colRemove)
        {
            int attemptsAllowed = 4;
            string fileToWrite = "";
            //Reads through the file and creates a new file
            RemoveEncryption(@ioFile);
            using (StreamReader reader = new StreamReader(@ioFile))
            {
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
            }
            AddEncryption(@ioFile);
        }

        /*
         * Method: ReserAttemptTry
         * Parameters: int rowRemove, int colRemove
         * Created By: Jordan Beck
         * Date: 4/4/2015
         * Modified By: Jordan Beck
         * 
         * Description: Reset the password attempts to 0
         */
        private void ResetAttemptTry(int rowRemove, int colRemove)
        {
            string fileToWrite = "";
            //Reads through the file and creates a new file
            RemoveEncryption(@ioFile);
            using (StreamReader reader = new StreamReader(@ioFile))
            {
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
            }
            AddEncryption(@ioFile);
        }

        /*
         * Method: ChangeFilePassword
         * Parameters: string username, string newPassword
         * Created By: Jordan Beck
         * Date: 4/2/2015
         * Modified By: Jordan Beck
         * 
         * Description: Changes the password for the user in the file.
         */
        private void ChangeFilePassword(string username, string newPassword)
        {
            bool admin = IsAdmin(username);
            DelUser(username);
            AddUser(username, newPassword, admin);
        }

        /*
         * Method: AddEncryption
         * Parameters: string fileName
         * Created By: Jordan Beck
         * Date: 4/14/2015
         * Modified By: Jordan Beck
         * 
         * Description: Encrypts the entire file
         */
        public void AddEncryption(string fileName)
        {
            string fileToWrite = "";
            //Reads through the file and creates a new file
            using (StreamReader reader = new StreamReader(@ioFile))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line != "")
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
                fileToWrite = Encryption.Encrypt(fileToWrite);
                writeFile.Write(fileToWrite);
                writeFile.Close();
            }
        }

        /*
         * Method: RemoveEncryption
         * Parameters: string fileName
         * Created By: Jordan Beck
         * Date: 4/14/2015
         * Modified By: Jordan Beck
         * 
         * Description: Decrypts the entire file.
         */
        public void RemoveEncryption(string fileName)
        {
            //File.Decrypt(FileName);
            string fileToWrite = "";
            //Reads through the file and creates a new file
            using (StreamReader reader = new StreamReader(@ioFile))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    line = Encryption.Decrypt(line);
                    if (line != "")
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
                //fileToWrite = Encryption.Encrypt(fileToWrite);
                writeFile.Write(fileToWrite);
                writeFile.Close();
            }

        }
    }
}
