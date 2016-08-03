function solve(){
    return function(){
        $.fn.listview = function(data){
            var $this = $(this),
                templateSelector = '#' + $this.attr('data-template'),
                templateHtml = $(templateSelector).html(),
                template = handlebars.compile(templateHtml),
                i, len;

            for(i = 0, len = data.length; i < len; i += 1) {
                $this.append(template(data[i]));
            }

            return this;
        };
    };
}