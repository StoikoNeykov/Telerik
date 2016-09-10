// from LinkedList
class Enumerable {
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
}

// from live demos without save this
class AnotherEnumerable {
    [Symbol.iterator]() {
        let index = -1;
        return {
            next: () => {
                index += 1;
                let isDone = false;
                if (index >= this._items.length) {
                    isDone = true;
                }

                return {
                    value: this._items[index],
                    done: isDone
                };
            }
        };
    }
}