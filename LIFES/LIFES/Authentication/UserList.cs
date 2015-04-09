using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LIFES.Authentication
{
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
        string ioFile = "C:/Users/Public/TestFolder/Username2.txt";

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
            }
        }
        public bool IsUser(string userName)
        {
            string testName = "";
            using (StreamReader reader = new StreamReader(@ioFile))
            {
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
        public bool IsAdmin(string inputName)
        {
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
            }
        }
        private void IncreaseAttemptTry(int rowRemove, int colRemove)
        {
            int attemptsAllowed = 4;
            string fileToWrite = "";
            //Reads through the file and creates a new file
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
        }
        private void ResetAttemptTry(int rowRemove, int colRemove)
        {
            string fileToWrite = "";
            //Reads through the file and creates a new file
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
        }
        private void ChangeFilePassword(string username, string newPassword)
        {
            bool admin = IsAdmin(username);
            DelUser(username);
            AddUser(username, newPassword, admin);
        }
    }
}