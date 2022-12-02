﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollBasics
{
/*Class:
 * 
 * Name
 * Professor
 * id
 * description
 * requisites
 * sections available (times)
 * year level
 * 
 */


    public static class Student
    {
        public static string name;
        private static int uID;
        public static string major;
        public static KeyValuePair<string, Requirement> requirements;
        public static List<Course> projectedSchedule;
        public static int totalCredits;

    }

    public class Course
    {
        public string id;
        public string name;
        public string description;
        public List<string> requisites;
        public List<Section> sections;
        public int yearLvl;
        public int credits;
    }

    public abstract class Requirement
    {
        public string displayName;
        public bool isFullfilled;
        public List<string> validCourses;

        public bool FullfillsRequirement(Course course)
        {
            foreach(Course course2 in validCourses)
            {
                if(course == course2)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class Section
    {
        public string professor;
        public SeatManager seats;
        public List<Session> sessions;
    }



    public class Session
    {
        public DateTime startTime;
        public DateTime endTime;
        public string location;
    }

    public class SeatManager
    {
        public int seatPosition;
        public int waitListPosition;
        public int capacity;
    }
}