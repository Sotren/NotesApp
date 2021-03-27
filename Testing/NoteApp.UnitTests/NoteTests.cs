using System;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class NoteTests
    {
        [Test]
        public void Name_GoodName_ReturnsSameName()
        {
            //Setup
            var note = new Note();
            var sourceName = "Сдать долг";
            var expectedName = sourceName;

            //Act
            note.Title = sourceName;
            var actualName = note.Title;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Text_GoodText_ReturnsSameText()
        {
            //Setup
            var note = new Note();
            var sourceName = "Откройте границу ";
            var expectedName = sourceName;

            //Act
            note.NoteDescription = sourceName;
            var actualName = note.NoteDescription;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Category_GoodCategory_ReturnsSameCategory()
        {
            //Setup
            var note = new Note();
            var sourceName = NotesCategory.Documents;
            var expectedName = sourceName;

            //Act
            note.NoteCategory = sourceName;
            var actualName = note.NoteCategory;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Create_GoodTimeCreate_ReturnsSameDate()
        {
            //Setup
            var note = new Note();
            var sourceName = new DateTime(2021, 3, 09);
            var expectedName = sourceName;

            //Act
            note.TimeCreated = sourceName;
            var actualName = note.TimeCreated;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Modify_GoodTimeModify_ReturnsSameDate()
        {
            //Setup
            var note = new Note();
            var sourceName = new DateTime(2021, 3, 09);
            var expectedName = sourceName;

            //Act
            note.TimeRecentUpdate = sourceName;
            var actualName = note.TimeRecentUpdate;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Name_BadName_ThrowsException()
        {
            //Setup
            var note = new Note();
            var sourceName ="Какой-то большой текст специално для провреки супер длинный и.....Очень нужный :)";

            //Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (
                () =>
                {
                    //Act
                    note.Title = sourceName;
                }
            );
        }

        [Test]
        public void Name_NoneName_ReturnsBasicName()
        {
            //Setup
            var note = new Note();
            var sourceName = "";
            var expectedName = "Безымянный";

            //Act
            note.Title = sourceName;
            var actualName = note.Title;

            //Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void Clone_GoodClone_ReturnSameData()
        {
            //Setup
            var sourceCategory = NotesCategory.Work;
            var notesCategory = sourceCategory;
            var expectedNote = new Note
            {
                Title = "Разработка",
                NoteDescription = "shit happens",
                NoteCategory = notesCategory,
                TimeCreated = new DateTime(2021, 3, 09),
                TimeRecentUpdate = new DateTime(2021, 3, 09)
            };
            
            //Act
            var actualNote = expectedNote.Clone() as Note;
            var expected = JsonConvert.SerializeObject(expectedNote);
            var actual = JsonConvert.SerializeObject(actualNote);

            //Assert
            NUnit.Framework.Assert.AreEqual(expected, actual);
        }
    }
}