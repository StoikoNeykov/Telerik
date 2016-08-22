/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function sum(numbers) {
	'use strict'

	// covered by 'use strict'
	// if (!numbers) {
	// 	throw new Error('Parameter numbers should be array of numbers!');
	// }

	if (!numbers.length) {
		return null;
	}

	return numbers.reduce(function (s, n) {
		var num = +n;
		
		if (isNaN(num)) {
			throw new Error('Array should contains only numbers!');
		}

		return s + num;
	}, 0);
}

module.exports = sum;