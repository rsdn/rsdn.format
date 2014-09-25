var RsdnFormat;
(function (RsdnFormat) {
    $(function () {
        $('div img').parent().addClass('image');
        $('.foldable .block-name').click(function (evt) {
            evt.preventDefault();
            var handle = $(evt.delegateTarget);
            handle.next().toggle('fast');
            handle.parent().toggleClass('folded');
        });
        $('.code').each(function (idx, elem) {
            hljs.highlightBlock(elem);
        });
    });
})(RsdnFormat || (RsdnFormat = {}));
//# sourceMappingURL=rsdn.format.js.map
