if (!Array.prototype.fill) {
    Array.prototype.fill = function (callback) {
        var i, len = this.length;
        for (i = 0; i < len; i += 1) {
            this[i] = arguments[0];
        }
        return this;
    };
}

if (!Array.prototype.find) {
    Array.prototype.find = function (callback) {
        var i, len = this.length;
        for (i = 0; i < len; i += 1) {
            if (callback(this[i], i, this)) {
                return this[i];
            }
        }
    }
}

if (!Array.prototype.findIndex) {
    Array.prototype.findIndex = function (callback) {
        var i, len = this.length;
        for (i = 0; i < len; i += 1) {
            if (callback(this[i], i, this)) {
                return i;
            }
        }
    }
}