const getId = (function() {
		let id = 0;

		return function() {
			id += 1;
			return id;
		};
	}());