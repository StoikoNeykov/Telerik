## XML Basics
### _Homework_

1.  What does the XML language represent? What is it used for? 
    _XML is human readable (unlike binary formats)_
    _Any kind of structured data can be stored_
    _Data comes with self-describing meta-data_
    _Custom XML-based languages can be developed for certain applications_
    _Information can be exchanged between different systems with ease_
    _Unicode is fully supported_
2.  Create XML document `students.xml`, which contains structured description of students.
  * For each student you should enter information for his name, sex, birth date, phone, email, course, specialty, faculty number and a list of taken exams (exam name, tutor, score).
3.  What do namespaces represent in an XML document? What are they used for? 
    _To disambiguate between two elements that happen to share the same name_
    _To group elements relating to a common idea together_
4.  Explore http://en.wikipedia.org/wiki/Uniform_Resource_Identifier to learn more about URI, URN and URL definitions.
5.  Add default namespace for students "`urn:students`".
6.  Create XSD Schema for `students.xml` document.
  * Add new elements in the schema: information for enrollment (date and exam score) and teacher's endorsements.
7.  Write an XSL stylesheet to visualize the students as HTML.
  * Test it in your favourite browser.
