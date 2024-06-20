
using System;

namespace HospitalSystem
{

  class Program
  {

	static string[,] Name = new string[21, 5];
	static int[,] Statis = new int[21, 5];
	static int[] Specializ_length = new int[21];

	static int List ()
	{
	  int choise = -1;
	  while (choise == -1)
		{
		  Console.WriteLine ("1) Add new patient ");
		  Console.WriteLine ("2) Print all patient ");
		  Console.WriteLine ("3) Get next patient ");
		  Console.WriteLine ("4) Exit ");
		  Console.Write ("Enter your choise ;");
		  choise = Convert.ToInt32 (Console.ReadLine ());
		  if (!(1 <= choise && choise <= 4))
			{
			  Console.WriteLine ("wrong number try again");
			  Console.WriteLine ("Enter number between 1 to 4 ");
			  choise = -1;
			}
		}
	  return choise;
	}

	static void Left_Shift (int Spec)
	{
	  int lentgh = Specializ_length[Spec];
	  for (int i = 0; i < lentgh; i++)
		{
		  Name[Spec, i] = Name[Spec, i + 1];
		  Statis[Spec, i] = Statis[Spec, i + 1];
		}
	  Specializ_length[Spec]--;
	}

	static void Right_Shift (int Spec)
	{
	  int lentgh = Specializ_length[Spec];
	  for (int i = lentgh - 1; i >= 0; i--)
		{
		  Name[Spec, i + 1] = Name[Spec, i];
		  Statis[Spec, i + 1] = Statis[Spec, i];
		}
	}

	static bool Addpatient ()
	{
	  Console.Write ("Enter name :");
	  string name1 = Convert.ToString (Console.ReadLine ());

	  Console.Write ("Enter Specialization (its number from 1 to 20):");
	  int Spec = Convert.ToInt32 (Console.ReadLine ());


	  int pos = Specializ_length[Spec];
	  if (pos >= 5)
		{
		  Console.
			WriteLine
			("sorry we can't add more patients for this specialization ");
		  return false;
		}
	  Console.Write ("Enter statis ('0' for regular,'1' for urgent ):");
	  int statis = Convert.ToInt32 (Console.ReadLine ());

	  if (statis == 0)
		{
		  Name[Spec, pos] = name1;
		  Statis[Spec, pos] = statis;
		  Specializ_length[Spec]++;
		}
	  else
		{
		  Right_Shift (Spec);
		  Name[Spec, 0] = name1;
		  Statis[Spec, 0] = statis;
		  Specializ_length[Spec]++;
		}
	  return true;
	}

	static void Print_All_Patient ()
	{
	  Console.WriteLine ("**********************************");
	  for (int Spec = 0; Spec < 21; ++Spec)
		{
		  if (Specializ_length[Spec] == 0)
			continue;
		  Console.WriteLine ("there are " + Specializ_length[Spec] +
							 " patient(s) in specialization " + Spec);

		  for (int i = 0; i < Specializ_length[Spec]; i++)
			{
			  Console.Write (Name[Spec, i]);

			  if (Statis[Spec, i] == 0)
				Console.WriteLine (" regular ");
			  else
				Console.WriteLine (" urgent ");
			}
		  Console.WriteLine ("\n");
		}
	}

	static void Get_Next_Patient ()
	{
	  Console.Write ("Enter specialization :");
	  int Spec = Convert.ToInt32 (Console.ReadLine ());
	  if (Specializ_length[Spec] == 0)
		{
		  Console.WriteLine ("no any one here Dr");
		  return;
		}
	  else
		{
		  Console.WriteLine (Name[Spec, 0] + " please go with the Dr");

		  Left_Shift (Spec);
		}
	}

	static void Hospital ()
	{
	  while (true)
		{
		  int choise = List ();

		  if (choise == 1)
			Addpatient ();
		  else if (choise == 2)
			Print_All_Patient ();
		  else if (choise == 3)
			Get_Next_Patient ();
		  else
			break;
		}
	}

	static void Main (string[]args)
	{
	  Hospital ();
	}

  }
}
