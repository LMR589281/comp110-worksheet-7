﻿using System;
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
            long size = GetFileSize(filePath);
            return size;
        }

		// Return true if the given path points to a directory, false if it points to a file
		public static bool IsDirectory(string path)
		{
			return File.GetAttributes(path).HasFlag(FileAttributes.Directory);
		}

		// Return the total size, in bytes, of all the files below the given directory
		public static long GetTotalSize(string directory)
		{
			throw new NotImplementedException();
		}

		// Return the number of files (not counting directories) below the given directory
		public static int CountFiles(string directory)
		{
            string[] files = Directory.GetFiles(directory);
            int length = files.Length;
            string[] folders = Directory.GetDirectories(directory);
            for (int i=0; folders.Length>i; i++) {
                length += CountFiles(folders[i]);
            }
            return length;
        }

		// Return the nesting depth of the given directory. A directory containing only files (no subdirectories) has a depth of 0.
		public static int GetDepth(string directory)
		{
            int depth = 0;
            string[] list = Directory.GetDirectories(directory);
            bool loop = true;
            while (loop == true) {
                if (list.Length >= 1)
                {
                    depth = +1;
                    list = Directory.GetDirectories(directory);
                }
                else
                {
                    loop = false;
                }
            }
            return depth;
        }

		// Get the path and size (in bytes) of the smallest file below the given directory
		public static Tuple<string, long> GetSmallestFile(string directory)
		{
			throw new NotImplementedException();
		}

		// Get the path and size (in bytes) of the largest file below the given directory
		public static Tuple<string, long> GetLargestFile(string directory)
		{
			throw new NotImplementedException();
		}

		// Get all files whose size is equal to the given value (in bytes) below the given directory
		public static IEnumerable<string> GetFilesOfSize(string directory, long size)
		{
			throw new NotImplementedException();
		}
	}
}
