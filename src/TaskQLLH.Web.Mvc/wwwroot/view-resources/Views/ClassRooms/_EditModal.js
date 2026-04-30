(function ($) {
    var _classRoomService = abp.services.app.classRoom,
        l = abp.localization.getSource('TaskQLLH'),
        _$modal = $('#ClassRoomEditModal'),
        _$form = _$modal.find('form');

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var classRoom = _$form.serializeFormToObject();

        abp.ui.setBusy(_$form);
        _classRoomService.update(classRoom).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('classRoom.edited', classRoom);
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    }

    _$form.closest('div.modal-content').find('.save-button').click(function (e) {
        e.preventDefault();
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    _$modal.on('shown.bs.modal', function () {
        // Lấy giá trị từ input hidden mà mình vừa thêm ở Bước 1
        var currentAcademicYear = $('#AcademicYearValue').val();

        // Truyền giá trị này vào hàm load
        loadAcademicYears(currentAcademicYear);

        _$form.find('input[type=text]:first').focus();
    });

    // =====================
    // ACADEMIC YEAR
    // =====================
    function generateAcademicYears() {
        let years = [];
        let current = new Date().getFullYear();

        for (let i = -2; i <= 3; i++) {
            let start = current + i;
            let end = start + 1;
            years.push(`${start}-${end}`);
        }

        return years;
    }

    function loadAcademicYears(selectedValue) {
        // Trỏ đúng vào ID AcademicYearEdit
        let select = $('#AcademicYearEdit');
        select.empty();

        let years = generateAcademicYears();

        years.forEach(y => {
            select.append(`<option value="${y}">${y}</option>`);
        });

        // ĐẶT GIÁ TRỊ SAU KHI ĐÃ APPEND OPTIONS
        if (selectedValue) {
            select.val(selectedValue);
        }
    }

})(jQuery);