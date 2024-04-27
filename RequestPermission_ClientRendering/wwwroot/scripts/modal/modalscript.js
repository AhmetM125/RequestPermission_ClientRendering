
window.OpenModal = (modalId) => {

    try {
    var modal = $(`#${modalId}`);
        modal.modal('show');
    }
    catch (e) {
        console.log(e);
    }
}
window.CloseModal = (modalId) => {
    try {
        var modal = $(`#${modalId}`);
        modal.modal('hide');
    } catch (e) {
        console.log(e);
    }

}


