function name(args) {    
    var num = +args[0];  
    var isPrime = true;
    if (num > 1) {
        for(var i = 2; i <= Math.sqrt(num) ; i += 1) {        
        if ((num % i) === 0) {
            isPrime = false;
            break;
        }
        }
    console.log(isPrime);
    }
    else{
        console.log("false");
    }
}