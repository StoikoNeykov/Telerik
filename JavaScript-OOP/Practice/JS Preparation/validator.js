const validator = {
    isBasicType(value, type) {
        return (typeof value === type)
    },
    isNotEmptyArray(arr) {
        return Array.isArray(arr) && arr.length !== 0
    },
    isObjectOfType(value, type) {
        if (!isBasicType(value, 'object')) {
            return false;
        } else {
            return (value instanceof type);
        }
    },
    isStringWithValidLength(str, min = 1, max = Number.MAX_VALUE) {
        if (!isBasicType(str, 'string')) {
            return false;
        } else {
            return min <= str.length && str.length <= max;
        }
    },
    isNumberInRange(num, min = Number.MIN_VALUE, max = Number.MAX_VALUE) {
        if (!isBasicType(num, 'number')) {
            return false;
        } else {
            return min <= num && num <= max;
        }
    },
    isItemLikeObject(value, type) {
        isType = Object.keys(new type)
            .every(function (key) {
                return (typeof value[key] !== 'undefined');
            });

        return isType;
    }
}