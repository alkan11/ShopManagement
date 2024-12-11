"use strict";

// Class definition
var KTFileManagerList = function () {


    // Define shared variables
    var datatable;
    var table

    // Define template element variables
    var uploadTemplate;
    var renameTemplate;
    var actionTemplate;
    var checkboxTemplate;


    // Private functions
    const initTemplates = () => {
        uploadTemplate = document.querySelector('[data-kt-filemanager-template="upload"]');
        renameTemplate = document.querySelector('[data-kt-filemanager-template="rename"]');
        actionTemplate = document.querySelector('[data-kt-filemanager-template="action"]');
        checkboxTemplate = document.querySelector('[data-kt-filemanager-template="checkbox"]');
    }

    const initDatatable = () => {
        // Set date data order
        const tableRows = table.querySelectorAll('tbody tr');

        tableRows.forEach(row => {
            const dateRow = row.querySelectorAll('td');
            const dateCol = dateRow[3]; // select date from 4th column in table
            const realDate = moment(dateCol.innerHTML, "DD MMM YYYY, LT").format();
            dateCol.setAttribute('data-order', realDate);
        });

        const foldersListOptions = {
            "info": false,
            'order': [],
            "scrollY": "700px",
            "scrollCollapse": true,
            "paging": false,
            'ordering': false,
            'columns': [
                { data: 'checkbox' },
                { data: 'name' },
                { data: 'size' },
                { data: 'date' },
                { data: 'action' },
            ],
            'language': {
                emptyTable: `<div class="d-flex flex-column flex-center">
                    <div class="fs-1 fw-bolder text-dark">Kayit Bulunamadi!</div>
                    <div class="fs-6">Yeni bir klasor ekleyebilirsiniz.</div>
                </div>`
            }
        };

        const filesListOptions = {
            "info": false,
            'order': [],
            'pageLength': 10,
            "lengthChange": false,
            'ordering': false,
            'columns': [
                { data: 'checkbox' },
                { data: 'name' },
                { data: 'size' },
                { data: 'date' },
                { data: 'action' },
            ],
            'language': {
                emptyTable: `<div class="d-flex flex-column flex-center">
                    <div class="fs-1 fw-bolder text-dark mb-4">Kayit Bulunamadi!</div>
                    <div class="fs-6">Yeni bir belge ekleyebilirsiniz.</div>
                </div>`
            },
            conditionalPaging: true
        };

        // Define datatable options to load
        var loadOptions;
        if (table.getAttribute('data-kt-filemanager-table') === 'folders') {
            loadOptions = foldersListOptions;
        } else {
            loadOptions = filesListOptions;
        }

        // Init datatable --- more info on datatables: https://datatables.net/manual/
        datatable = $(table).DataTable(loadOptions);

        // Re-init functions on every table re-draw -- more info: https://datatables.net/reference/event/draw
        datatable.on('draw', function () {
            initToggleToolbar();
            toggleToolbars();
            resetNewFolder();
            KTMenu.createInstances();
        });
    }

    // Search Datatable --- official docs reference: https://datatables.net/reference/api/search()
    const handleSearchDatatable = () => {
        const filterSearch = document.querySelector('[data-kt-filemanager-table-filter="search"]');
        filterSearch.addEventListener('keyup', function (e) {
            datatable.search(e.target.value).draw();
        });
    }


    // Init toggle toolbar
    const initToggleToolbar = () => {
        // Toggle selected action toolbar
        // Select all checkboxes
        var checkboxes = table.querySelectorAll('[type="checkbox"]');
        if (table.getAttribute('data-kt-filemanager-table') === 'folders') {
            checkboxes = document.querySelectorAll('#kt_file_manager_list_wrapper [type="checkbox"]');
        }

        // Select elements
        const deleteSelected = document.querySelector('[data-kt-filemanager-table-select="delete_selected"]');

        // Toggle delete selected toolbar
        checkboxes.forEach(c => {
            // Checkbox on click event
            c.addEventListener('click', function () {
                console.log(c);
                setTimeout(function () {
                    toggleToolbars();
                }, 50);
            });
        });

        // Deleted selected rows
        deleteSelected.addEventListener('click', function () {
            // SweetAlert2 pop up --- official docs reference: https://sweetalert2.github.io/
            Swal.fire({
                text: "Are you sure you want to delete selected files or folders?",
                icon: "warning",
                showCancelButton: true,
                buttonsStyling: false,
                confirmButtonText: "Yes, delete!",
                cancelButtonText: "No, cancel",
                customClass: {
                    confirmButton: "btn fw-bold btn-danger",
                    cancelButton: "btn fw-bold btn-active-light-primary"
                }
            }).then(function (result) {
                if (result.value) {
                    Swal.fire({
                        text: "You have deleted all selected  files or folders!.",
                        icon: "success",
                        buttonsStyling: false,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: "btn fw-bold btn-primary",
                        }
                    }).then(function () {
                        // Remove all selected customers
                        checkboxes.forEach(c => {
                            if (c.checked) {
                                datatable.row($(c.closest('tbody tr'))).remove().draw();
                            }
                        });

                        // Remove header checked box
                        const headerCheckbox = table.querySelectorAll('[type="checkbox"]')[0];
                        headerCheckbox.checked = false;
                    });
                } else if (result.dismiss === 'cancel') {
                    Swal.fire({
                        text: "Selected  files or folders was not deleted.",
                        icon: "error",
                        buttonsStyling: false,
                        confirmButtonText: "Ok, got it!",
                        customClass: {
                            confirmButton: "btn fw-bold btn-primary",
                        }
                    });
                }
            });
        });
    }

    // Toggle toolbars
    const toggleToolbars = () => {
        // Define variables
        const toolbarBase = document.querySelector('[data-kt-filemanager-table-toolbar="base"]');
        const toolbarSelected = document.querySelector('[data-kt-filemanager-table-toolbar="selected"]');
        const selectedCount = document.querySelector('[data-kt-filemanager-table-select="selected_count"]');

        // Select refreshed checkbox DOM elements 
        const allCheckboxes = table.querySelectorAll('tbody [type="checkbox"]');

        // Detect checkboxes state & count
        let checkedState = false;
        let count = 0;

        // Count checked boxes
        allCheckboxes.forEach(c => {
            if (c.checked) {
                checkedState = true;
                count++;
            }
        });

        // Toggle toolbars
        if (checkedState) {
            selectedCount.innerHTML = count;
            toolbarBase.classList.add('d-none');
            toolbarSelected.classList.remove('d-none');
        } else {
            toolbarBase.classList.remove('d-none');
            toolbarSelected.classList.add('d-none');
        }
    }


    // Reset add new folder input
    const resetNewFolder = () => {
        const newFolderRow = table.querySelector('#kt_file_manager_new_folder_row');

        if (newFolderRow) {
            newFolderRow.parentNode.removeChild(newFolderRow);
        }
    }
    var myDropzone = new Dropzone("#kt_ecommerce_add_product_media", {
        url: "/Documents/AddFile", // Set the url for your upload script location
        paramName: "file", // The name that will be used to transfer the file
        maxFiles: 10,
        maxFilesize: 10, // MB
        addRemoveLinks: true,
        accept: function (file, done) {
            console.log(file)
            $.ajax({
                type: "POST",
                url: "/Documents/AddFile",
                data: { file: encodeURIComponent(JSON.stringify(file.upload)), folderId: folderId },
                success: function (sonuc) {
                    if (sonuc != null && sonuc.ok) {
                        console.log(sonuc)
                        if (sonuc.control == 1) {
                            toastr.error("��lem ger�ekle�irken hata olu�tu. Dosya y�klenemedi");
                        }
                        else if (sonuc.control == 2) {
                            toastr.error("��lem ger�ekle�irken hata olu�tu. Klas�r bulunamad��� i�in belge klas�re eklenemedi.");
                        }
                        else {
                            toastr.success("Dosya klas�re ba�ar� ile y�klendi.");
                            window.location.reload(true);
                        }
                    }
                    else {
                        toastr.success("��lem ger�ekle�irken hata olu�tu.");
                    }
                }
            });
        }
    });

    // Rename callback
    const renameCallback = (e) => {
        e.preventDefault();

        // Define shared value
        let nameValue;

        // Stop renaming if there's an input existing
        if (table.querySelectorAll('#kt_file_manager_rename_input').length > 0) {
            Swal.fire({
                text: "Unsaved input detected. Please save or cancel the current item",
                icon: "warning",
                buttonsStyling: false,
                confirmButtonText: "Ok, got it!",
                customClass: {
                    confirmButton: "btn fw-bold btn-danger"
                }
            });

            return;
        }

        // Select parent row
        const parent = e.target.closest('tr');

        // Get name column
        const nameCol = parent.querySelectorAll('td')[1];
        const colIcon = nameCol.querySelector('.svg-icon');
        nameValue = nameCol.innerText;

        // Set rename input template
        const renameInput = renameTemplate.cloneNode(true);
        renameInput.querySelector('#kt_file_manager_rename_folder_icon').innerHTML = colIcon.outerHTML;

        // Swap current column content with input template
        nameCol.innerHTML = renameInput.innerHTML;

        // Set input value with current file/folder name
        parent.querySelector('#kt_file_manager_rename_input').value = nameValue;

        // Rename file / folder validator
        var renameValidator = FormValidation.formValidation(
            nameCol,
            {
                fields: {
                    'rename_folder_name': {
                        validators: {
                            notEmpty: {
                                message: 'Name is required'
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

        // Rename input button action
        //const renameInputButton = document.querySelector('#kt_file_manager_rename_folder');
        //renameInputButton.addEventListener('click', e => {
        //    e.preventDefault();

        //    // Detect if valid
        //    if (renameValidator) {
        //        renameValidator.validate().then(function (status) {
        //            console.log('validated!');

        //            if (status == 'Valid') {
        //                // Pop up confirmation
        //                Swal.fire({
        //                    text: "Are you sure you want to rename " + nameValue + "?",
        //                    icon: "warning",
        //                    showCancelButton: true,
        //                    buttonsStyling: false,
        //                    confirmButtonText: "Yes, rename it!",
        //                    cancelButtonText: "No, cancel",
        //                    customClass: {
        //                        confirmButton: "btn fw-bold btn-danger",
        //                        cancelButton: "btn fw-bold btn-active-light-primary"
        //                    }
        //                }).then(function (result) {
        //                    if (result.value) {
        //                        Swal.fire({
        //                            text: "You have renamed " + nameValue + "!.",
        //                            icon: "success",
        //                            buttonsStyling: false,
        //                            confirmButtonText: "Ok, got it!",
        //                            customClass: {
        //                                confirmButton: "btn fw-bold btn-primary",
        //                            }
        //                        }).then(function () {
        //                            // Get new file / folder name value
        //                            const newValue = document.querySelector('#kt_file_manager_rename_input').value;

        //                            // New column data template
        //                            const newData = `<div class="d-flex align-items-center">
        //                                ${colIcon.outerHTML}
        //                                <a href="?page=apps/file-manager/files/" class="text-gray-800 text-hover-primary">${newValue}</a>
        //                            </div>`;

        //                            // Draw datatable with new content -- Add more events here for any server-side events
        //                            datatable.cell($(nameCol)).data(newData).draw();
        //                        });
        //                    } else if (result.dismiss === 'cancel') {
        //                        Swal.fire({
        //                            text: nameValue + " was not renamed.",
        //                            icon: "error",
        //                            buttonsStyling: false,
        //                            confirmButtonText: "Ok, got it!",
        //                            customClass: {
        //                                confirmButton: "btn fw-bold btn-primary",
        //                            }
        //                        });
        //                    }
        //                });
        //            }
        //        });
        //    }
        //});

        //// Cancel rename input
        //const cancelInputButton = document.querySelector('#kt_file_manager_rename_folder_cancel');
        //cancelInputButton.addEventListener('click', e => {
        //    e.preventDefault();

        //    // Simulate process for demo only
        //    cancelInputButton.setAttribute("data-kt-indicator", "on");

        //    setTimeout(function () {
        //        const revertTemplate = `<div class="d-flex align-items-center">
        //            ${colIcon.outerHTML}
        //            <a href="?page=apps/file-manager/files/" class="text-gray-800 text-hover-primary">${nameValue}</a>
        //        </div>`;

        //        // Remove spinner
        //        cancelInputButton.removeAttribute("data-kt-indicator");

        //        // Draw datatable with new content -- Add more events here for any server-side events
        //        datatable.cell($(nameCol)).data(revertTemplate).draw();

        //        // Toggle toastr
        //        toastr.options = {
        //            "closeButton": true,
        //            "debug": false,
        //            "newestOnTop": false,
        //            "progressBar": false,
        //            "positionClass": "toastr-top-right",
        //            "preventDuplicates": false,
        //            "showDuration": "300",
        //            "hideDuration": "1000",
        //            "timeOut": "5000",
        //            "extendedTimeOut": "1000",
        //            "showEasing": "swing",
        //            "hideEasing": "linear",
        //            "showMethod": "fadeIn",
        //            "hideMethod": "fadeOut"
        //        };

        //        toastr.error('Cancelled rename function');
        //    }, 1000);
        //});
    }

    // Init dropzone
    const initDropzone = () => {
        // set the dropzone container id
        const id = "#kt_modal_upload_dropzone";
        const dropzone = document.querySelector(id);

        // set the preview element template
        var previewNode = dropzone.querySelector(".dropzone-item");
        previewNode.id = "";
        var previewTemplate = previewNode.parentNode.innerHTML;
        previewNode.parentNode.removeChild(previewNode);

        var myDropzone = new Dropzone(id, { // Make the whole body a dropzone
            url: "C:\Users\simse\OneDrive\Masa�st�\Alkan", // Set the url for your upload script location
            parallelUploads: 10,
            previewTemplate: previewTemplate,
            maxFilesize: 1, // Max filesize in MB
            autoProcessQueue: false, // Stop auto upload
            autoQueue: false, // Make sure the files aren't queued until manually added
            previewsContainer: id + " .dropzone-items", // Define the container to display the previews
            clickable: id + " .dropzone-select" // Define the element that should be used as click trigger to select files.
        });

        myDropzone.on("addedfile", function (file) {
            // Hook each start button
            file.previewElement.querySelector(id + " .dropzone-start").onclick = function () {
                // myDropzone.enqueueFile(file); -- default dropzone function

                // Process simulation for demo only
                const progressBar = file.previewElement.querySelector('.progress-bar');
                progressBar.style.opacity = "1";
                var width = 1;
                var timer = setInterval(function () {
                    if (width >= 100) {
                        myDropzone.emit("success", file);
                        myDropzone.emit("complete", file);
                        clearInterval(timer);
                    } else {
                        width++;
                        progressBar.style.width = width + '%';
                    }
                }, 20);
            };

            const dropzoneItems = dropzone.querySelectorAll('.dropzone-item');
            dropzoneItems.forEach(dropzoneItem => {
                dropzoneItem.style.display = '';
            });
            dropzone.querySelector('.dropzone-upload').style.display = "inline-block";
            dropzone.querySelector('.dropzone-remove-all').style.display = "inline-block";
        });

        // Hide the total progress bar when nothing's uploading anymore
        myDropzone.on("complete", function (file) {
            const progressBars = dropzone.querySelectorAll('.dz-complete');
            setTimeout(function () {
                progressBars.forEach(progressBar => {
                    progressBar.querySelector('.progress-bar').style.opacity = "0";
                    progressBar.querySelector('.progress').style.opacity = "0";
                    progressBar.querySelector('.dropzone-start').style.opacity = "0";
                });
            }, 300);
        });

        // Setup the buttons for all transfers
        dropzone.querySelector(".dropzone-upload").addEventListener('click', function () {
            // myDropzone.processQueue(); --- default dropzone process

            // Process simulation for demo only
            myDropzone.files.forEach(file => {
                const progressBar = file.previewElement.querySelector('.progress-bar');
                progressBar.style.opacity = "1";
                var width = 1;
                var timer = setInterval(function () {
                    if (width >= 100) {
                        myDropzone.emit("success", file);
                        myDropzone.emit("complete", file);
                        clearInterval(timer);
                    } else {
                        width++;
                        progressBar.style.width = width + '%';
                    }
                }, 20);
                $.ajax({
                    type: "POST",
                    url: "/Documents/AddFile",
                    data: { file: encodeURIComponent(JSON.stringify(file.upload)), folderId: folderId },
                    success: function (sonuc) {
                        if (sonuc != null && sonuc.ok) {
                            console.log(sonuc)
                            if (sonuc.control == 1) {
                                toastr.error("��lem ger�ekle�irken hata olu�tu. Dosya y�klenemedi");
                            }
                            else if (sonuc.control == 2) {
                                toastr.error("��lem ger�ekle�irken hata olu�tu. Klas�r bulunamad��� i�in belge klas�re eklenemedi.");
                            }
                            else {
                                toastr.success("Dosya klas�re ba�ar� ile y�klendi.");
                                window.location.reload(true);
                            }
                        }
                        else {
                            toastr.success("��lem ger�ekle�irken hata olu�tu.");
                        }
                    }
                });
            });
        });

        // Setup the button for remove all files
        dropzone.querySelector(".dropzone-remove-all").addEventListener('click', function () {
            dropzone.querySelector('.dropzone-upload').style.display = "none";
            dropzone.querySelector('.dropzone-remove-all').style.display = "none";
            myDropzone.removeAllFiles(true);
        });

        // On all files completed upload
        myDropzone.on("queuecomplete", function (progress) {
            const uploadIcons = dropzone.querySelectorAll('.dropzone-upload');
            uploadIcons.forEach(uploadIcon => {
                uploadIcon.style.display = "none";
            });
        });

        // On all files removed
        myDropzone.on("removedfile", function (file) {
            if (myDropzone.files.length < 1) {
                dropzone.querySelector('.dropzone-upload').style.display = "none";
                dropzone.querySelector('.dropzone-remove-all').style.display = "none";
            }
        });
    }


    // Public methods
    return {
        init: function () {
            table = document.querySelector('#kt_file_manager_list');

            if (!table) {
                return;
            }

            initTemplates();
            initDatatable();
            initToggleToolbar();
            handleSearchDatatable();
            initDropzone();
            KTMenu.createInstances();
        }
    }
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
    KTFileManagerList.init();
});