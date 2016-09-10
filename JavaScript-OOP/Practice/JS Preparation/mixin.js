let myCrazyUselessMixin = Base => class extends Base {
    constructor(...args){
        super(...args)
    }
    useless1() {
        return null;
    }
    useless2(param) {
        console.log(param);
    }
}

class MyClassThatNeedUselessMethods extends myCrazyUselessMixin(Object){
    constructor() {
        super();
    }
}