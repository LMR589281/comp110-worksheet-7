using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace comp110_worksheet_7
{
	public static class DirectoryUtils
	{
		// Return the size, in bytes, of the given file
		public static long GetFileSize(string filePath)
		{
            long size = GetFileSize(filePath);    //get the file size of the given file
            return size;    //returns the size
        }

		// Return true if the given path points to a directory, false if it points to a file
		public static bool IsDirectory(string path)
		{
			return File.GetAttributes(path).HasFlag(FileAttributes.Directory);
		}

		// Return the total size, in bytes, of all the files below the given directory
		public static long GetTotalSize(string directory)
		{
            long size = 0;    //sets the value of size to be 0
            string[] files = Directory.GetFileSystemEntries(directory);    //gets an array of folders and files
            for (int i = 0; files.Length > i; i++)    //loops for the length of the array of folders and files
            {
                if (IsDirectory(files[i]) == true)    //checks to see if a folder is in the list
                {
                    size += GetTotalSize(files[i]);    //if a folder is in the list then the function is called again to check inside the folder
                }
                else     //if the item in the list is not a folder and thus a file
                {
                    size +=  GetFileSize(files[i]);    //the size of the file is added to the size value
                }
            }
            return size;    //the size value is returned back
        }

		// Return the number of files (not counting directories) below the given directory
		public static int CountFiles(string directory)
		{
            int amount_of_files = 0;    //sets the value amount_of_files to be 0
            string[] folders = Directory.GetDirectories(directory);    //puts all the folders into a new array called "folders" 
            for (int i=0; folders.Length>i; i++)    //loops for the amount of folders
            {
                amount_of_files += CountFiles(folders[i]);    //checks folders inside folders
            }
            return amount_of_files;    //returns the amount of files
        }

		// Return the nesting depth of the given directory. A directory containing only files (no subdirectories) has a depth of 0.
		public static int GetDepth(string directory)
		{
            int depth = 0;    //sets depth to equal 0
            string[] folders = Directory.GetDirectories(directory);    //makes an array of folders
            bool loop = true;    //sets loop to be true
            for (int i = 0; folders.Length > i; i++)    //loops for the length of the folders array
            {  
                if (folders.Length >= 1)    //checks if the folder length is bigger than 1
                {
                    depth += 1;     //increases depth by 1
                    folders = Directory.GetDirectories(folders[i]);     //checks the current folder for more folders
                }
            }
            return depth;    //returns the depth value
        }

		// Get the path and size (in bytes) of the smallest file below the given directory
		public static Tuple<string, long> GetSmallestFile(string directory)
		{
            long smallest = 9223372036854775807;    //largest long value, so no files size should be larger than this
            string location = "";     //sets the location of the files to a empty string
            string[] files = Directory.GetFileSystemEntries(directory);      //makes an array of folders and files
            for (int i=0 ; files.Length>i; i++)      //loop for the length of the files
            {
                if (IsDirectory(files[i]) == true)     //if the item in the array is a folder
                {
                    location, smallest = GetSmallestFile(files[i]);     //then we check inside the folder for files NOT WORKING
                }
                else     //if the item in the array is not a folder and thus a file
                {     
                    if (GetFileSize(files[i]) < smallest)     //checks to see if the fil is smaller then the current smallest file
                    {
                        smallest = GetFileSize(files[i]);     //set the new smallest value
                        location = files[i];     //set the new location for the smallest value
                    }
                }
            }
            Tuple<string, long> answer = new Tuple<string, long>(location, largest);     //sets up a tuple
            return answer;     //returns the tuple
        }

		// Get the path and size (in bytes) of the largest file below the given directory
		public static Tuple<string, long> GetLargestFile(string directory)
		{
            long largest = 0;    //sets longest to be 0
            string location = "";     //sets the location of the files to a empty string
            string[] files = Directory.GetFileSystemEntries(directory);      //makes an array of folders and files
            for (int i = 0; files.Length > i; i++)      //loop for the length of the files
            {
                if (IsDirectory(files[i]) == true)     //if the item in the array is a folder
                {
                    location, smallest = GetSmallestFile(files[i]);     //then we check inside the folder for files NOT WORKING
                }
                else     //if the item in the array is not a folder and thus a file
                {
                    if (GetFileSize(files[i]) > largest)     //checks to see if the fil is smaller then the current smallest file
                    {
                        largest = GetFileSize(files[i]);     //set the new largest value
                        location = files[i];     //set the new location for the largest value
                    }
                }
            }
            Tuple<string, long> answer = new Tuple<string, long>(location, largest);     //sets up a tuple
            return answer;     //returns the tuple
        }
		}

		// Get all files whose size is equal to the given value (in bytes) below the given directory
		public static IEnumerable<string> GetFilesOfSize(string directory, long size)
		{
        string[] same_size;     //makes an array of strings called "same_size"
        string[] files = Directory.GetFileSystemEntries(directory);     //gets an array of files
        for (int i = 0; files.Length > i; i++)     //loops for the length of the files
        {
            if (IsDirectory(files[i]) == true)     //if the item in the array is a folder then
            {
                same_size_plus = GetFileSystemEntries(files[i]);     //we check the folder for files
                same_size.Add(same_size_plus);     //add any new items to the array
            }
            else     //if the item in the array is not a folder and thus a file
            {
                if (GetFileSize(files[i]) = size)     //check to see if we have the right size
                {
                    same_size.Add(files[i]);     //add the files to the array
                }
            }
        }
        return same_size;     //return the list of arrays
    }
}

