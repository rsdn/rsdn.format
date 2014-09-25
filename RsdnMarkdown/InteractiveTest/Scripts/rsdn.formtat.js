/// <reference path="../Scripts/typings/highlightjs/highlightjs.d.ts"/>
var RsdnFormat;
(function (RsdnFormat) {
    $(function () {
        $('.foldable .block-name').click(function (evt) {
            evt.preventDefault();
            var handle = $(evt.delegateTarget);
            handle.next().toggle('fast');
            handle.parent().toggleClass('folded');
        });
        $('code').each(function (idx, elem) {
            hljs.highlightBlock(elem);
        });
    });
})(RsdnFormat || (RsdnFormat = {}));
//# sourceMappingURL=rsdn.formtat.js.map
