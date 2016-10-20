## Database Systems - Overview
### _Homework_

### Answer following questions in Markdown format (`.md` file)

#### _1.  What database models do you know?_
    Hierarchical, Network, Relational, Object-oriented     
#### _2.  Which are the main functions performed by a Relational Database Management System (RDBMS)?_
    Creating / altering / deleting tables and relationships between them (database schema)
    Adding, changing, deleting, searching and retrieving of data stored in the tables
#### _3.  Define what is "table" in database terms._
    Tables consist of data, arranged in rows and columns. Table rows have the same structure
#### _4.  Explain the difference between a primary and a foreign key._
    Primary key is a column of the table that uniquely identifies its rows (usually its is a number)
    The foreign key is an identifier of a record located in another table (usually its primary key)
#### _5.  Explain the different kinds of relationships between tables in relational databases._
    one-to-many: A single record in the first table has many corresponding records in the second table
    many-to-many: Records in the first table have many correspon-ding records in the second one
    one-to-one: A single record in a table corresponds to a single record in the other table
#### _6.  When is a certain database schema normalized?_
####   _* What are the advantages of normalized databases?_
    Normalization of the relational schema removes repeating data.
    Usually normalized database need less space and work faster. 
#### _7.  What are database integrity constraints and when are they used?_
    Integrity constraints ensure data integrity in the database tables.
    Enforce data rules which cannot be violated. Usually always.
#### _8.  Point out the pros and cons of using indexes in a database._
    Indices speed up searching of values in a certain column or group of columns
    Usually implemented as B-trees
    Indices can be built-in the table (clustered) or stored externally (non-clustered)
    Adding and deleting records in indexed tables is slower!
    Indices should be used for big tables only (e.g. 50 000 rows)
#### _9.  What's the main purpose of the SQL language?_
    Creating, altering, deleting tables and other objects in the database
    Searching, retrieving, inserting, modifying and deleting table data (rows)
#### _10.  What are transactions used for?_
####   _* Give an example._
    Transactions are a sequence of database operations which are executed as a single unit:
    Either all of them execute successfully
    Or none of them is executed at all
#### _11.  What is a NoSQL database?_
    NoSQL (non-relational) databases
    Use document-based model (non-relational)
    Schema-free document storage
    Still support CRUD operations
    Create, Read, Update, Delete
    Still support indexing and querying
    Still supports concurrency and transactions
    ighly optimized for append / retrieve
    Great performance and scalability
#### _12.  Explain the classical non-relational data models._
    Usually kind of key-value pairs.
#### _13.  Give few examples of NoSQL databases and their pros and cons._
    Redis: Ultra-fast in-memory data structures server
    MongoDB: Mature and powerful JSON-document database
    CouchDB: JSON-based document database with REST API
    Cassandra: Distributed wide-column database
