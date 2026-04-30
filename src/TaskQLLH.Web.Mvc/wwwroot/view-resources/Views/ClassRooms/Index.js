(function ($) {
    var _classRoomService = abp.services.app.classRoom,
        l = abp.localization.getSource('TaskQLLH'),
        _$modal = $('#ClassRoomCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#ClassRoomsTable');

    // =====================
    // KHỞI TẠO DATATABLE
    // =====================
    var _$classRoomsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _classRoomService.getAll,
            inputFilter: function () {
                return {
                    filter: $('#FilterText').val(),
                    status: $('#StatusFilter').val() || undefined
                };
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$classRoomsTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                data: 'name',
                sortable: false
            },
            {
                targets: 1,
                data: 'code',
                sortable: false
            },
            {
                targets: 2,
                data: 'academicYear',
                sortable: false
            },
            {
                targets: 3,
                data: 'semester',
                sortable: false,
                render: data => `${l('Semester')} ${data}`
            },
            {
                targets: 4,
                data: 'maxStudents',
                sortable: false
            },
            {
                targets: 5,
                data: 'status',
                sortable: false,
                render: function (data) {
                    var statusMap = {
                        1: { label: l('ClassRoomActive'),    css: 'badge-success' },
                        2: { label: l('ClassRoomInactive'),  css: 'badge-warning' },
                        3: { label: l('ClassRoomCompleted'), css: 'badge-info'    },
                        4: { label: l('ClassRoomCancelled'), css: 'badge-danger'  }
                    };
                    var s = statusMap[data] || { label: data, css: 'badge-secondary' };
                    return `<span class="badge ${s.css}">${s.label}</span>`;
                }
            },
            {
                targets: 6,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row) => {
                    return [
                        `<button type="button" class="btn btn-sm bg-secondary edit-classRoom" data-classRoom-id="${row.id}" data-toggle="modal" data-target="#ClassRoomEditModal">`,
                        `    <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        `</button>`,
                        `<button type="button" class="btn btn-sm bg-danger delete-classRoom" data-classRoom-id="${row.id}" data-classRoom-name="${row.name}">`,
                        `    <i class="fas fa-trash"></i> ${l('Delete')}`,
                        `</button>`
                    ].join('');
                }
            }
        ]
    });

    // =====================
    // TÌM KIẾM
    // =====================
    $('.btn-search').on('click', () => {
        _$classRoomsTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which === 13) {
            _$classRoomsTable.ajax.reload();
            return false;
        }
    });

    $('#GetClassRoomsButton').on('click', () => {
        _$classRoomsTable.ajax.reload();
    });

    $('#FilterText').on('keypress', (e) => {
        if (e.which === 13) {
            _$classRoomsTable.ajax.reload();
        }
    });

    // =====================
    // THÊM MỚI
    // =====================
    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var classRoom = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);
        _classRoomService.create(classRoom).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$classRoomsTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    // =====================
    // CHỈNH SỬA
    // =====================
    $(document).on('click', '.edit-classRoom', function (e) {
        var classRoomId = $(this).attr('data-classRoom-id');

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'ClassRoom/EditModal?classRoomId=' + classRoomId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#ClassRoomEditModal div.modal-content').html(content);
            },
            error: function (e) {
                console.error(e);
            }
        });
    });

    abp.event.on('classRoom.edited', () => {
        _$classRoomsTable.ajax.reload();
    });

    // =====================
    // XÓA
    // =====================
    $(document).on('click', '.delete-classRoom', function () {
        var classRoomId = $(this).attr('data-classRoom-id');
        var classRoomName = $(this).attr('data-classRoom-name');

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                classRoomName
            ),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _classRoomService.delete({
                        id: classRoomId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$classRoomsTable.ajax.reload();
                    });
                }
            }
        );
    });

})(jQuery);