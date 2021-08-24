// ******************************************************
// Intro
// Hiện modal
$('#btn-modal-intro').on('click', function () {
    $('#modal-intro').fadeToggle(500)
})


// Ẩn modal - Save
$('.btn-save-my-modal-intro').on('click', function () {
    $('#modal-intro').fadeToggle(500)

    const items = $('.intro-item')
    let ind = 0;

    $(items).each((i, item) => {
        if (item.value) {
            // Cập nhật class Id
            // id = StoryIntroDescriptionItems_0_
            // name = StoryIntroDescriptionItems[0]

            $(item).attr('id', `StoryIntroDescriptionItems_${ind}_`)
            $(item).attr('name', `StoryIntroDescriptionItems[${ind++}]`)
        }
        else {
            $(item).parent().remove()
        }
    })

})

// Add  new item
$('.btn-add-new-intro-item').on('click', function (e) {
    e.preventDefault();

    const parent = $('.modal-body-intro')
    const newItem = $(`<div class="d-flex">
                            <input type="text" name="StoryIntroDescriptionItems" placeholder="Bạn muốn nói gì..." class="intro-item" />
                            <a href="#" class="remove-intro-item"><i class="fas fa-minus text-danger"></i></a>
                        </div>`)

    parent.append(newItem)
})

// Remove  new item
$('body').on('click', '.remove-intro-item', function () {
    $(this).parent().remove()
})

// ******************************************************
// Poem
// Hiện modal
$('#btn-modal-poem').on('click', function () {
    $('#modal-poem').fadeToggle(500)
})


// Ẩn modal - Save
$('.btn-save-my-modal-poem').on('click', function () {
    $('#modal-poem').fadeToggle(500)
})

// ******************************************************
// Celebrate
// Hiện modal
$('#btn-modal-celebrate').on('click', function () {
    $('#modal-celebrate').fadeToggle(500)
})


// Ẩn modal - Save
$('.btn-save-my-modal-celebrate-create').on('click', function () {
    $('#modal-celebrate').fadeToggle(500)

    const imageItems = $('.celebrate-image-item')
    const descriptionItems = $('.celebrate-description-item')
    let ind = 0;

    $(imageItems).each((i, item) => {
        if (item.files && item.files[0] && descriptionItems[i].value) {
        }
        else {
            $(item).parent().remove()
        }
    })

})

// Ẩn modal - Save
$('.btn-save-my-modal-celebrate-update').on('click', function () {
    $('#modal-celebrate').fadeToggle(500)

    const idItems = $('.celebrate-id-item')
    const imageItems = $('.celebrate-image-item')
    const descriptionItems = $('.celebrate-description-item')
    let ind = 0;

    $(imageItems).each((i, item) => {

        let check = true
        // Xóa các thừa
        if (idItems[i].value > 0) {
            // Cái cũ

        } else {
            // Thêm mới
            if (!item.files || !item.files[0] || !descriptionItems[i].value) {
                console.log('asdas')
                $(item).parent().remove()
                check = false
            }
        }

        // Cập nhật name id
        if (check) {
            idItems[i].setAttribute('id', `CelebrateUpdateRequests_${ind}__Id`)
            idItems[i].setAttribute('name', `CelebrateUpdateRequests[${ind}].Id`)

            imageItems[i].setAttribute('id', `CelebrateUpdateRequests_${ind}__Image`)
            imageItems[i].setAttribute('name', `CelebrateUpdateRequests[${ind}].Image`)

            descriptionItems[i].setAttribute('id', `CelebrateUpdateRequests_${ind}__Description`)
            descriptionItems[i].setAttribute('name', `CelebrateUpdateRequests[${ind++}].Description`)
        }
    })

})

// Add  new item
$('.btn-add-new-celebrate-item-create').on('click', function (e) {
    e.preventDefault();

    const parent = $('.modal-body-celebrate')
    const newItem = $(` <div class="d-flex">
                            <input type="file" name="StoryCelebrateImageItems" placeholder="Ảnh..." class="celebrate-image-item" />
                            <input type="text" name="StoryCelebrateDescriptionItems" placeholder="Nội dung..." class="celebrate-description-item" />
                            <a href="#" class="remove-celebrate-item"><i class="fas fa-minus text-danger"></i></a>
                        </div>`)

    parent.append(newItem)
})

$('.btn-add-new-celebrate-item-update').on('click', function (e) {
    e.preventDefault();

    const parent = $('.modal-body-celebrate')
    const newItem = $(` <div class="d-flex">
                            <input type="hidden" class="celebrate-id-item"/>
                            <input type="file" accept=".jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff|image/*" placeholder="Ảnh..." class="celebrate-image-item" />
                            <input type="text"   placeholder="Nội dung..."  class="celebrate-description-item" />
                            <a href="#" class="remove-celebrate-item"><i class="fas fa-minus text-danger"></i></a>
                        </div>`)

    parent.append(newItem)
})

// Remove  new item
$('body').on('click', '.remove-celebrate-item', function () {
    $(this).parent().remove()
})