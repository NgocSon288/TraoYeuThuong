$(document).ready(function () {

    var current_fs, next_fs, previous_fs; //fieldsets
    var opacity;

    $(".next").click(function () {

        // Globals  story
        if ($(this).attr('id') === 'store-1') {
            const nameIn = document.querySelector('#StoryName')
            const avatarIn = document.querySelector('#StoryAvatar')
            const descriptionIn = document.querySelector('#Description')

            if (!nameIn.value) {
                alert('Tên của story không được bỏ trống!')
                return
            }

            if (!avatarIn.files || !avatarIn.files[0]) {
                alert('Ảnh nền không được bỏ trống!')
                return
            }

            if (!descriptionIn.value) {
                alert('Mô tả không được bỏ trống!')
                return
            }
        }

        // End Globals story

        // Intro
        if ($(this).attr('id') === 'store-2') {
            const introBackgroundIn = document.querySelector('#IntroBackground')
            const introAudioIn = document.querySelector('#IntroAudio')
            const introItems = $('.intro-item')
            const introQuesttionIn = document.querySelector('#IntroQuesttion')

            if (!introBackgroundIn.files || !introBackgroundIn.files[0]) {
                alert('Ảnh nền không được bỏ trống!')
                return
            }

            if (!introAudioIn.files || !introAudioIn.files[0]) {
                alert('Nhạc nền không được bỏ trống!')
                return
            }

            if (introItems.length < 3) {
                alert('Phải có ít nhất 3 câu nói!')
                return
            }

            if (!introQuesttionIn.value) {
                alert('Phải có câu hỏi cuối trang!')
                return
            }


        }
        // End Intro

        // Poem
        if ($(this).attr('id') === 'store-3') {
            const poemTitleIn = document.querySelector('#PoemTitle')
            const poemAuthorIn = document.querySelector('#PoemAuthor')
            const poemBackgroundIn = document.querySelector('#PoemBackground')
            const poemAudioIn = document.querySelector('#PoemAudio')
            const poemItems = $('.poem-item')

            if (!poemTitleIn.value) {
                alert('Tiêu đề không được bỏ trống')
                return
            }

            let title = poemTitleIn.value.trim();
            while (title.indexOf('  ') >= 0) {
                title = title.replace('  ', ' ')
            }

            if (title.split(' ').length !== 2) {
                alert('Tiêu để phải có đúng 2 từ')
                return
            }

            poemTitleIn.value = title.split(' ')[0].concat(' ', title.split(' ')[1])

            if (!poemAuthorIn.value) {
                alert('Tác giả không được bỏ trống')
                return
            }

            if (!poemBackgroundIn.files || !poemBackgroundIn.files[0]) {
                alert('Ảnh nền không được bỏ trống!')
                return
            }

            if (!poemAudioIn.files || !poemAudioIn.files[0]) {
                alert('Nhạc nền không được bỏ trống!')
                return
            }

            let checkPoemItems =   true

            poemItems.each((i, item) => {
                if (!item.value) {
                    checkPoemItems = false;
                }
            })

            if (!checkPoemItems) {
                alert('Phải đủ  12 câu thơ!')
                return
            }
        }
        // End Poem


        // Celebrate
        if ($(this).attr('id') === 'store-4') {
            const celebrateTitleIn = document.querySelector('#CelebrateTitle')
            const celebrateBackgroundIn = document.querySelector('#CelebrateBackground')
            const celebrateAudioIn = document.querySelector('#CelebrateAudio')
            const celebrateImageItems = $('.celebrate-image-item')
            const celebrateDescriptioItems = $('.celebrate-description-item')

            if (!celebrateTitleIn.value) {
                alert('Tiêu đề trang không được bỏ trống!')
                return
            }

            if (!celebrateBackgroundIn.files || !celebrateBackgroundIn.files[0]) {
                alert('Ảnh nền không được bỏ trống!')
                return
            }

            if (!celebrateAudioIn.files || !celebrateAudioIn.files[0]) {
                alert('Nhạc nền không được bỏ trống!')
                return
            }

            let count = 0;

            celebrateImageItems.each((i, item) => {
                if (!item.value || !celebrateDescriptioItems[i].value) {
                    item.parentElement.remove()
                } else {
                    count++
                }
            })

            if (count<4) {
                alert('Phải có ít nhất 4 kỷ niệm!')
                return
            }

            $('#msform').submit()

        }
        // End Celebrate

        current_fs = $(this).parent();
        next_fs = $(this).parent().next();

        //Add Class Active
        $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

        //show the next fieldset
        next_fs.show();
        //hide the current fieldset with style
        current_fs.animate({ opacity: 0 }, {
            step: function (now) {
                // for making fielset appear animation
                opacity = 1 - now;

                current_fs.css({
                    'display': 'none',
                    'position': 'relative'
                });
                next_fs.css({ 'opacity': opacity });
            },
            duration: 600
        });
    });

    $(".previous").click(function () {



        current_fs = $(this).parent();
        previous_fs = $(this).parent().prev();

        //Remove class active
        $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

        //show the previous fieldset
        previous_fs.show();

        //hide the current fieldset with style
        current_fs.animate({ opacity: 0 }, {
            step: function (now) {
                // for making fielset appear animation
                opacity = 1 - now;

                current_fs.css({
                    'display': 'none',
                    'position': 'relative'
                });
                previous_fs.css({ 'opacity': opacity });
            },
            duration: 600
        });
    });

    $('.radio-group .radio').click(function () {
        $(this).parent().find('.radio').removeClass('selected');
        $(this).addClass('selected');
    });

    $(".submit").click(function () {
        return false;
    })

});