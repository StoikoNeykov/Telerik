function solve() {
	'use strict'

	let lastId = 0;

	class Item {
		constructor(name, description) {
			this.id = (lastId += 1);
			this.name = name;
			this.description = description;
		}

		get name() {
			return this._name;
		}

		set name(value) {
			if (typeof value !== 'string' || value.length < 2 || value.length > 40) {
				throw new Error('Name should be string between 2 and 40 symbols long!');
			}

			this._name = value;
		}

		get description() {
			return this._description;
		}

		set description(value) {
			if (typeof value !== 'string' || value === '') {
				throw new Error('Description should be non-empty string!')
			}

			this._description = value;
		}
	}

	class Book extends Item {
		constructor(name, isbn, genre, description) {
			super(name, description);
			this.isbn = isbn;
			this.genre = genre;
		}

		get isbn() {
			return this._isbn;
		}

		set isbn(value) {
			const isNum = /^\d+$/.test(value),
				// just in case it is not
				isbn = value.toSting();

			if (!isNum || isbn.length !== 10 && isbn.length !== 13) {
				throw new Error('Isbn should be 10 or 13 digits!')
			}

			this._isbn = isbn;
		}

		get genre() {
			return this._genre;
		}

		set genre(value) {
			if (typeof value !== 'string' || value.length < 2 || value.length > 20) {
				throw new Error('Genre should be string between 2 and 20 symbols long!')
			}

			this._genre = value;
		}
	}

	class Media extends item {
		constructor(name, rating, duration, description) {
			super(name, description);
			this.rating = rating;
			this.duration = duration;
		}

		get duration() {
			return this._duration;
		}

		set duration(value) {
			if (typeof duration !== 'number' || duration <= 0) {
				throw new Error('Duration should be number bigger then 0!');
			}

			this._duration = value;
		}

		get rating() {
			return this._rating;
		}

		set rating(value) {
			if (typeof value !== 'number' || value < 1 || value > 5) {
				throw new Error('Rating should be number between 1 and 5!');
			}

			this._rating = value;
		}
	}

	class Catalog {
		constructor(name) {
			this.id = (lastId += 1);
			this.name = name;
			this.items = [];
		}

		get name() {
			return this._name;
		}

		set name(value) {
			if (typeof value !== 'string' || value.length < 2 || value.length > 40) {
				throw new Error('Name should be string between 2 and 40 symbols long!');
			}

			this._name = value;
		}

		_itemLikeObjectValidation(item) {
			return (item instanceof Item) ||
				(typeof item.id === 'string' &&
					typeof item.name === 'string' &&
					typeof item.description === 'string')
		}

		add(...itemsToAdd) {
			if (Array.isArray(itemsToAdd[0])) {
				itemsToAdd = itemsToAdd[0];
			}

			if (itemsToAdd.length === 0) {
				throw 'Cannot call Add without parameters!';
			}

			if (!itemsToAdd.every(this._itemLikeObjectValidation)) {
				throw 'Invalid items!';
			}

			this.items.push(...itemsToAdd);
		}

		find(options) {
			if (typeof options === 'undefined') {
				throw 'Cannot use find without parameters!';
			}

			let isSingleResult = false;
			if (typeof options === 'number') {
				options = {
					id: options
				}

				isSingleResult = true;
			}

			if (typeof options !== 'object') {
				throw 'Invalid find options!';
			}

			let result = this.items.filter(item =>
				Object.keys(options)
					.every(key => item[key] === options[key])
			);

			return (!isSingleResult) ? result : (result.length) ? result[0] : null;
		}

		search(patern) {
			if (typeof patern !== 'string' || patern.length === 0) {
				throw 'Invalid patern!';
			}

			patern = patern.toLowerCase();

			let result = this.items.filter(item =>
				(item.name.toLowerCase().indexOf(patern) > 0 ||
					item.description.toLowerCase().indexOf(patern) > 0)
			);

			return result;
		}
	}

	class BookCatalog extends Catalog {
		constructor(name) {
			super(name);
		}

		_itemLikeObjectValidation(item) {
			return super._itemLikeObjectValidation(item) &&
				((item instanceof Book) ||
					(typeof item._isbn === 'string' &&
						typeof item._genre === 'string'))
		}

		getGenres() {
			let genres = {};
			this.items.forEach(item =>
				genres[item.genre] = true);

			return Object.keys(genres);
		}
	}

	class MediaCatalog extends Catalog {
		constructor(name) {
			super(name);
		}

		_itemLikeObjectValidation(item) {
			return super._itemLikeObjectValidation(item) &&
				((item instanceof Media) ||
					(typeof item._duration === 'number' &&
						typeof item._rating === 'number'))
		}

		getTop(count) {
			if (typeof count !== 'number' || count < 1) {
				throw 'Count should be positive number';
			}

			let result = this.items
				.sort((a, b) => a.rating - b.rating)
				.slice(0, count)
				.map(item => {
					return {
						id: item.id,
						name: item.name
					};
				});

			return result;
		}

		getSortedByDuration() {
			return [...this.items]
				.sort((a, b) => (a.duration === b.duration) ? a.duration - b.duration : a.id - b.id)
		}
	}

	return {
		getBook: function (name, isbn, genre, description) {
			return new Book(name, isbn, genre, description);
		},
		getMedia: function (name, rating, duration, description) {
			return new Media(name, rating, duration, description);
		},
		getBookCatalog: function (name) {
			return new BookCatalog(name);
		},
		getMediaCatalog: function (name) {
			return new MediaCatalog(name);
		}
	};
}

var module = solve();
var catalog = module.getBookCatalog('John\'s catalog');

var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
catalog.add(book1);
catalog.add(book2);

console.log(catalog.find(book1.id));
//returns book1

console.log(catalog.find({ id: book2.id, genre: 'IT' }));
//returns book2

console.log(catalog.search('js'));
// returns book2

console.log(catalog.search('javascript'));
//returns book1 and book2

console.log(catalog.search('Te sa zeleni'))
//returns []
