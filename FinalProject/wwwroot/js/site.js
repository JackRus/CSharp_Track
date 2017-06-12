// Write your Javascript code.

//  QR CODE Script
$(document).ready(function() {
	/* Creates QR code */
	$("#qr").qrcode({
		width: 99,
		height: 96,
		render : "table",
		text   : "Jack Rus, T-Mobile, Manager"
	});
});
//  END of QR CODE Script