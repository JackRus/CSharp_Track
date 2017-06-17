// Write your Javascript code.

$(document).ready(function() {
	/* Creates QR code */
	$("#qr").qrcode({
		width: 99,
		height: 96,
		render : "table",
		text   : "8932234343"
	});
});