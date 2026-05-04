using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ConsoleApp9
{
    public class MyXmlSerialization : MySerializater
    {


        public new void Serialize()
        {
            var ser = new XmlSerializer(typeof(Student[]));
            _path = Path.Combine(_desktopPath, "example.xml");
            using (var fs = new StreamWriter(_path))
            {
                var dtoobj = new List<DTOstudent>(_students.Count);
                foreach (var student in _students)
                {
                    dtoobj.Add(new DTOstudent(student));
                }
                ser.Serialize(fs, dtoobj.ToArray());
            }
        }
        public new void Deserialize()
        {

        }
        public class DTOstudent
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public Subject[] Subjects { get; set; }
            public DTOstudent()
            {

            }
            public DTOstudent(Student s)
            {
                Id = s.Id;
                Name = s.Name;
                Surname = s.Surname;
                Subjects = s.Subjects;
                var dtoobj = new List<DTOsubject>(s.Subjects.Count());
                foreach (var subject in s.Subjects)
                {
                    dtoobj.Add(new DTOsubject(subject));
                }
            }
            public Student Getstudent()
            {
                return new Student(Id, Surname, Name, Subjects);
            }
        }
        public class DTOsubject
        {
            public string Name { get; set; }
            public int[] Marks { get; set; }
            public DTOsubject() { }
            public DTOsubject(Subject s)
            {
                Name = s.Name;
                Marks = s.Marks;
            }

            public Subject Getsub()
            {
                return new Subject(Name, Marks);
            }
            
        }
    }
}
