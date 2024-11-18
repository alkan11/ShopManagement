"use strict";

// Class definition
var KTModalNewTarget = function () {
	var submitButton;
	var cancelButton;
	var validator;
	var form;
	var modal;
	var modalEl;

	// Init form inputs
	var initForm = function() {
		// Tags. For more info, please visit the official plugin site: https://yaireo.github.io/tagify/
		var tags = new Tagify(form.querySelector('[name="tags"]'), {
			whitelist: ["Important", "Urgent", "High", "Medium", "Low"],
			maxTags: 5,
			dropdown: {
				maxItems: 10,           // <- mixumum allowed rendered suggestions
				enabled: 0,             // <- show suggestions on focus
				closeOnSelect: false    // <- do not hide the suggestions dropdown once an item has been selected
			}
		});
		tags.on("change", function(){
			// Revalidate the field when an option is chosen
            validator.revalidateField('tags');
		});

		// Due date. For more info, please visit the official plugin site: https://flatpickr.js.org/
		var dueDate = $(form.querySelector('[name="CreatedDate"]'));
		dueDate.flatpickr({
			enableTime: false,
			dateFormat: "d, M Y",
		});

		// Team assign. For more info, plase visit the official plugin site: https://select2.org/
        $(form.querySelector('[name="team_assign"]')).on('change', function() {
            // Revalidate the field when an option is chosen
            validator.revalidateField('team_assign');
        });
	}

	// Handle form validation and submittion
	var handleForm = function() {
		// Stepper custom navigation

		// Init form validation rules. For more info check the FormValidation plugin's official documentation:https://formvalidation.io/
		validator = FormValidation.formValidation(
			form,
			{
				fields: {
					target_title: {
						validators: {
							notEmpty: {
								message: 'Bu alan zorunludur'
							}
						}
					},
					target_assign: {
						validators: {
							notEmpty: {
								message: 'Bu alan zorunludur'
							}
						}
					},
					target_dueDate: {
						validators: {
							notEmpty: {
								message: 'Bu alan zorunludur'
							}
						}
					},
					target_tags: {
						validators: {
							notEmpty: {
								message: 'Bu alan zorunludur'
							}
						}
					},
					'targets_notifications[]': {
                        validators: {
                            notEmpty: {
                                message: 'Please select at least one communication method'
                            }
                        }
                    },
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


		// Action buttons
		submitButton.addEventListener('click', function (e) {
			e.preventDefault();

			// Validate form before submit
			if (validator) {
				validator.validate().then(function (status) {
					console.log('validated!');

					if (status == 'Valid') {
						submitButton.setAttribute('data-kt-indicator', 'on');

						// Disable button to avoid multiple click 
						submitButton.disabled = true;

						setTimeout(function() {
							submitButton.removeAttribute('data-kt-indicator');

							// Enable button
							submitButton.disabled = false;
							
							// Show success message. For more info check the plugin's official documentation: https://sweetalert2.github.io/
							//Swal.fire({
							//	text: "Form has been successfully submitted!",
							//	icon: "success",
							//	buttonsStyling: false,
							//	confirmButtonText: "Ok, got it!",
							//	customClass: {
							//		confirmButton: "btn btn-primary"
							//	}
							//}).then(function (result) {
							//	if (result.isConfirmed) {
							//		modal.hide();
							//	}
							//});

							form.submit(); // Submit form
						}, 1000);   						
					} else {
						// Show error message.
						Swal.fire({
							text: "Zorunlu alanlar\u0131 doldurun ve l\u00fctfen tekrar deneyin",
							icon: "error",
							buttonsStyling: false,
							confirmButtonText: "Tamam",
							customClass: {
								confirmButton: "btn btn-primary"
							}
						});
					}
				});
			}
		});

		cancelButton.addEventListener('click', function (e) {
			e.preventDefault();
			form.reset();
			modal.hide();
			validator.resetForm(true);
			//Swal.fire({
			//	text: "Are you sure you would like to cancel?",
			//	icon: "warning",
			//	showCancelButton: true,
			//	buttonsStyling: false,
			//	confirmButtonText: "Yes, cancel it!",
			//	cancelButtonText: "No, return",
			//	customClass: {
			//		confirmButton: "btn btn-primary",
			//		cancelButton: "btn btn-active-light"
			//	}
			//}).then(function (result) {
			//	if (result.value) {
			//		form.reset(); // Reset form	
			//		modal.hide(); // Hide modal				
			//	} else if (result.dismiss === 'cancel') {
			//		Swal.fire({
			//			text: "Your form has not been cancelled!.",
			//			icon: "error",
			//			buttonsStyling: false,
			//			confirmButtonText: "Ok, got it!",
			//			customClass: {
			//				confirmButton: "btn btn-primary",
			//			}
			//		});
			//	}
			//});
		});
	}

	return {
		// Public functions
		init: function () {
			// Elements
			modalEl = document.querySelector('#kt_modal_new_target');

			if (!modalEl) {
				return;
			}

			modal = new bootstrap.Modal(modalEl);

			form = document.querySelector('#kt_modal_new_target_form');
			submitButton = document.getElementById('kt_modal_new_target_submit');
			cancelButton = document.getElementById('kt_modal_new_target_cancel');

			initForm();
			handleForm();
		}
	};
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
	KTModalNewTarget.init();
});