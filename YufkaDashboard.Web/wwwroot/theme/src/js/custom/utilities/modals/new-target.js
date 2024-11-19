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

		// Due date. For more info, please visit the official plugin site: https://flatpickr.js.org/
		var dueDate = $(form.querySelector('[name="CreatedDate"]'));
		dueDate.flatpickr({
			enableTime: false,
			dateFormat: "d, M Y",
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
					'Name': {
						validators: {
							notEmpty: {
								message: 'Bu alan zorunludur'
							}
						}
					},
					'Type': {
						validators: {
							notEmpty: {
								message: 'Bu alan zorunludur'
							}
						}
					},
					'CreateDate': {
						validators: {
							notEmpty: {
								message: 'Bu alan zorunludur'
							}
						}
					},
					'UnitPrice': {
						validators: {
							notEmpty: {
								message: 'Bu alan zorunludur'
							}
						}
					},
					'Description': {
						validators: {
							notEmpty: {
								message: 'Bu alan zorunludur'
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

		cancelButton.addEventListener('click', function (e) {
			e.preventDefault();
			form.reset();
			modal.hide();
			validator.resetForm(true);
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