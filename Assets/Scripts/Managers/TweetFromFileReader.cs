using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;  


public class TweetFromFileReader : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
	
	
		static public ArrayList readJsonFromFile (string fileName, long firstLine, long lastLine)
		{
				ArrayList listOfJsonStrings = new ArrayList ();
				// Handle any problems that might arise when reading the text
				try {
						string line;
						// Create a new StreamReader, tell it which file to read and what encoding the file
						// was saved as
						StreamReader theReader = new StreamReader (fileName, Encoding.Default);
			
						// Immediately clean up the reader after this block of code is done.
						// You generally use the "using" statement for potentially memory-intensive objects
						// instead of relying on garbage collection.
						// (Do not confuse this with the using directive for namespace at the 
						// beginning of a class!)
						
						long currentRow = 0;
						using (theReader) {
								// While there's lines left in the text file, do this:
								do {
										line = theReader.ReadLine ();
										
										if (firstLine <= currentRow && line != null) {
												// Do whatever you need to do with the text line, it's a string now
												// In this example, I split it into arguments based on comma
												// deliniators, then send that array to DoStuff()
												//Debug.Log ("got line");
												//Debug.Log (line);
												listOfJsonStrings.Add (line);
										}
										++currentRow;
								} while (line != null && currentRow <= lastLine);
				
								// Done reading, close the reader and return true to broadcast success    
								theReader.Close ();
						}
				}
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (IOException e) {
						Debug.Log ("{0}\n" + e.Message);
				}
				Debug.Log ("Reader read. " + listOfJsonStrings.Count + " strings");
				return listOfJsonStrings;
		}
}
