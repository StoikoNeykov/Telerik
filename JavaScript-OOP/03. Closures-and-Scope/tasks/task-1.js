/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/
function solve() {
	'use strict';
	var library = (function () {
		var books = [];
		var categories = [];

		function listBooks(needed) {
			// throw new Error(JSON.stringify(needed));
			if (!needed) {
				return books;
			} else if (needed.category) {
				return books.filter(function (current) {
					return current.category === needed.category;
				})
			} else if (needed.author) {
				return books.filter(function (current) {
					return current.author === needed.author;
				})
			} else {
				return books;
			}
		}

		function validateBook(book) {
			if (typeof book.title !== 'string' || book.title.length < 2 || book.title.length > 100) {
				throw new Error('Book title should be string between 2 and 100 symbols!');
			}

			if (typeof book.category !== 'string' || book.category.length < 2 || book.category.length > 100) {
				throw new Error('Book catagory should be string between 2 and 100 symbols!');
			}

			if (typeof book.author !== 'string' || book.author === '') {
				throw new Error('Book author should be not empty string!');
			}

			var isbn = parseInt(book.isbn);

			if (!((999999999 < isbn && isbn < 10000000000) || (999999999999 < isbn && isbn < 10000000000000))) {
				throw new Error('Book ISBN should be 10 or 13 symbols');
			}

			books.forEach(b => {
				if (b.title === book.title || b.isbn === book.isbn) {
					throw new Error('Book title and ISBN should be unique!');
				}
			})
		}

		function addCategory(category) {
			categories.push(category);
		}

		function addBook(book) {
			validateBook(book);

			if (categories.indexOf(book.category) < 0) {
				addCategory(book.category);
			}

			book.ID = books.length + 1;
			books.push(book);
			return book;
		}

		function listCategories() {
			return categories;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());
	return library;
}
module.exports = solve;
