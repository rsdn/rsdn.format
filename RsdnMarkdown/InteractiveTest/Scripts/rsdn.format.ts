/// <reference path="typings/jquery/jquery.d.ts"/>

declare module hljs {
	export function highlightBlock(block: Node): void;
}

module RsdnFormat {
	$(() => {
		$('div img').parent().addClass('image');
		$('.foldable .block-name').click(evt => {
			evt.preventDefault();
			var handle = $(evt.delegateTarget);
			handle.next().toggle('fast');
			handle.parent().toggleClass('folded');
		});
		$('.code').each((idx, elem) => {
			hljs.highlightBlock(elem);
		});
	});
} 