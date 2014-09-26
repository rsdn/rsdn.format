/// <reference path="typings/jquery/jquery.d.ts"/>

declare module hljs {
	export function highlightBlock(block: Node): void;
}

module RsdnFormat {
	$(() => {
		var format = $('.format');
		// Add class for proper image handles styling
		format.find('div img').parent().addClass('image');
		format.find('div blockquote').parent().addClass('quote');
		format.find('div .code').parent().addClass('code-box');

		// Foldable blocks
		format.find('.foldable .block-name').click(evt => {
			evt.preventDefault();
			var handle = $(evt.delegateTarget);
			handle.next().toggle('fast');
			handle.parent().toggleClass('folded');
		});

		// Code syntax highlight
		format.find('.code').each((idx, elem) => {
			hljs.highlightBlock(elem);
		});

		// Table zebra
		var rows = format.find('table tr');
		rows.filter(':odd').addClass('odd');
		rows.filter(':even').addClass('even');
	});
}