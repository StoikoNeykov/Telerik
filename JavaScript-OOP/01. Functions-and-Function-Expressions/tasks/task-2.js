/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function findPrimes(min, max) {
	var i,
		result = [];

	min = +min;
	max = +max;


	if (isNaN(min) || isNaN(max)) {
		throw new Error('Input parameters should be numbers!');
	}

	function isPrime(num) {
		var end,
			j;

		if (num < 2) {
			return false;
		}

		for (j = 2, end = Math.sqrt(num); j <= end; j += 1) {
			if (!(num % j)) {
				return false;
			}
		}

		return true;
	}

	for (i = Math.ceil(min); i <= max; i += 1) {
		if (isPrime(i)) {
			result.push(i);
		}
	}

	return result;
}

module.exports = findPrimes;
