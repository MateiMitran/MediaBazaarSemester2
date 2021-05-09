$(document).ready(function() {
    // CHANGE DASHBOARD VIEW WHEN CLICKING ON BUTTON
    $('.dashboard-button').click(function() {
        let page = $(this).attr('page')
        
        // CHANGE DASHBOARD VIEW
        $('.dashboard-content').fadeOut(100).removeClass('visible').delay(100)
        $(`#${page}`).fadeIn(100).addClass('visible')

        // CHANGE PAGE TITLE
        let title = $(this).text().trim()
        $('#dashboard-wrapper .section-title').text(title)
    })

    // HIDE END DATE INPUT IN ABSENCE TAB

    $('#day-off-form #one-day-only').click(function() {
        if($('#day-off-form #one-day-only:checked').length > 0) {
            $('#end-day-form-group').css('display', 'none');
        } else {
            $('#end-day-form-group').css('display', 'block');
        }
    })
})