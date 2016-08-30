'use strict';

class listNode {
    constructor(value) {
        this._data = value;
        this._next = null;
    }

    get data() {
        return this._data;
    }
}

class LinkedList {
    constructor() {
        this._length = 0;
        this._head = null;

        return this;
    }

    get first() {
        return this._head.data;
    }

    get last() {
        return this.at(this._length - 1);
    }

    get length() {
        return this._length;
    }


    append(...args) {
        for (const arg of args) {
            var node = new listNode(arg);

            if (this._head === null) {
                this._head = node;
            } else {
                var current = this._head;

                while (current._next) {
                    current = current._next;
                }

                current._next = node;
            }

            this._length += 1;
        }

        return this;
    }

    prepend(...args) {
        args = args.reverse();
        for (const arg of args) {
            let old = this._head,
                newNode = new listNode(arg);

            this._head = newNode;
            this._head._next = old;

            this._length += 1;
        }

        return this;
    }

    insert(index, ...args) {
        if (index === 0) {
            this.prepend(...args);
        } else {
            let i = 0,
                current = this._head,
                previous;

            while (i++ < index) {
                previous = current;
                current = current._next;
            }

            for (const arg of args) {
                let newNode = new listNode(arg);
                previous._next = newNode;
                newNode._next = current;

                previous = newNode;

                this._length += 1;
            }
        }

        return this;
    }

    [Symbol.iterator]() {
        let current = this._head;

        return {
            i: 0,
            next() {
                if (current) {
                    this.i += 1;
                    let now = current;
                    current = current._next;

                    return {
                        value: now.data,
                        done: false
                    }
                } else {
                    return {
                        value: undefined,
                        done: true
                    }
                }
            }
        }
    }

    removeAt(index) {
        if (index === 0) {
            let old = this._head;
            this._head = this._head._next;
            this._length -= 1;

            return old.data;

        } else if (0 < index && index < this.length) {
            let previous = this._head,
                current = previous._next,
                i = 1;

            while (i !== index) {
                previous = current;
                current = previous._next;

                i += 1;
            }

            previous._next = current._next;

            this._length -= 1;

            return current.data;

        } else {
            return null;
        }
    }

    at(index, value) {
        if (value !== undefined) {
            this.insert(index, value);
            this.removeAt(index + 1);
        } else {
            if (0 <= index && index < this._length) {
                var current = this._head,
                    i = 0;

                while (i++ < index) {
                    current = current._next;
                }

                return current.data;
            } else {
                return null;
            }
        }
    }

    toArray() {
        let result = [],
            current = this._head;
        result.push(current.data);

        while (current._next) {
            current = current._next;
            result.push(current.data);
        }

        return result;
    }

    toString() {
        return this.toArray().join(' -> ');
    }
}

module.exports = LinkedList;