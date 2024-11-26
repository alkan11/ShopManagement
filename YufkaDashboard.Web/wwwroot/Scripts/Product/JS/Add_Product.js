//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function GetRowDetail(id) {

	var uri = "/Product/UpdateProduct/" + id;
	$('#frmUpdateProduct').attr('action', uri);

	$.ajax({
		type: "GET",
		url: "/Product/GetProductById",
		dataType: "json",
		data: { "id": id },
		success: function (sonuc) {
			if (sonuc != null) {

				$("#uName").val(sonuc.name);
				$("#uType").val(sonuc.type).change();
				$("#uUnitPrice").val(sonuc.unitPrice);
				$("#uflatpickr-date").val(sonuc.createdDate);
				$("#uDescription").val(sonuc.description);
				$("#uStatus").prop("checked", sonuc.status);
			}
		}
	});
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
function DeleteStringRecord(id, systemId) {

	const swalWithBootstrapButtons = Swal.mixin({
		customClass: {
			confirmButton: "btn btn-success",
			cancelButton: "btn btn-danger"
		},
		buttonsStyling: false
	});

	if (systemId == 1) {
		swalWithBootstrapButtons.fire({
			title: "Silinemez",
			text: "Bu kayıt sistem bir kaydıdır.",
			icon: "error"
		});
	}
	else {
		swalWithBootstrapButtons.fire({
			title: "Silmek istediğinizden emin misiniz?",
			text: "Yaptığınız işlemin geri dönüşü yoktur!",
			icon: "warning",
			showCancelButton: true,
			confirmButtonText: "Evet",
			cancelButtonText: "Hayır",
			reverseButtons: false
		}).then((result) => {
			if (result.isConfirmed) {

				$.ajax({
					type: "GET",
					url: "/Product/DeleteStringRecord",
					dataType: "json",
					data: { "id": id },
					success: function (result) {
						if (result != null) {

							if (result.ok) {
								window.location.reload(true);
							}
							else {
								swalWithBootstrapButtons.fire({
									title: "İşlem gerçekleşmedi",
									text: result.text,
									icon: "error"
								});
							}
						}
					}
				});


			}
		});
	}


}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

window.onload = function () {
	$("#uflatpickr-date").flatpickr();

	// Define form element
	//add_form validation
	const form = document.getElementById('add_product_form');

	// Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
	var validator = FormValidation.formValidation(
		form,
		{
			fields: {
				'Name': {
					validators: {
						notEmpty: {
							message: 'Bu alan zorunlu'
						}
					}
				},
				'Type': {
					validators: {
						notEmpty: {
							message: 'Bu alan zorunlu'
						}
					}
				},
				'UnitPrice': {
					validators: {
						notEmpty: {
							message: 'Bu alan zorunlu'
						}
					}
				},
				'CreatedDate': {
					validators: {
						date: {
							format: 'YYYY-MM-DD',
							message: 'Bu tarih geçerli değil',
						},
						notEmpty: {
							message: 'Bu alan zorunlu'
						}
					}
				}
			},

			plugins: {
				trigger: new FormValidation.plugins.Trigger(),
				bootstrap: new FormValidation.plugins.Bootstrap5({
					rowSelector: '.fv-row',
					eleInvalidClass: '',
					eleValidClass: ''
				})
			}
		}
	);


	// Submit button handler
	const submitButton = document.getElementById('product_modal_submit');
	submitButton.addEventListener('click', function (e) {
		// Prevent default button action
		e.preventDefault();

		// Validate form before submit
		if (validator) {
			validator.validate().then(function (status) {
				console.log('validated!');

				if (status == 'Valid') {
					// Show loading indication
					submitButton.setAttribute('data-kt-indicator', 'on');

					// Disable button to avoid multiple click
					submitButton.disabled = true;

					// Simulate form submission. For more info check the plugin's official documentation: https://sweetalert2.github.io/
					setTimeout(function () {
						// Remove loading indication
						submitButton.removeAttribute('data-kt-indicator');

						// Enable button
						submitButton.disabled = false;

						form.submit(); // Submit form
					}, 100);
				}
			});
		}
	});

	const cancelButton = document.getElementById('product_modal_cancel');
	cancelButton.addEventListener('click', function (e) {
		e.preventDefault();
		form.reset();
		validator.resetForm(true);
		document.getElementById('product_modal_cancel').setAttribute('data-bs-dismiss', 'modal');
	});
	
};


