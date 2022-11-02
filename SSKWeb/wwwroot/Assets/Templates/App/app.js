
if (typeof App === 'undefined') App = {};

App.showErrorModal = function (msg) {
    $("#error-msg-modal").clone().modal("show").find("#error-msg-body").html(msg);
};

$('.alpha-numeric').keyboard({
    usePreview: false,
    layout: 'custom',
    restrictInput: true, // Prevent keys not in the displayed keyboard from being typed in
    preventPaste: true,  // prevent ctrl-v and right click
    autoAccept: true,
    maxLength: 30,
    useCombos: false,
    customLayout: {
        'normal': [
            '1 2 3 4 5 6 7 8 9 0',
            'q w e r t y u i o p',
            'a s d f g h j k l {bksp}',
            'z x c v b n m - . {s}',
            '{cancel} {accept}'
        ],
        'shift': [
            '1 2 3 4 5 6 7 8 9 0',
            'Q W E R T Y U I O P',
            'A S D F G H J K L {bksp}',
            'Z X C V B N M - . {s}',
            '{cancel} {accept}'
        ]
    },
    css: {
        // input & preview
        input: 'form-control input-sm',
        // keyboard container
        container: 'center-block dropdown-menu', // jumbotron
        // default state
        buttonDefault: 'btn btn-default',
        // hovered button
        buttonHover: 'btn-primary',
        // Action keys (e.g. Accept, Cancel, Tab, etc);
        // this replaces "actionClass" option
        buttonAction: 'active',
        // used when disabling the decimal button {dec}
        // when a decimal exists in the input area
        buttonDisabled: 'disabled'
    }
});


$('.alpha').keyboard({
    usePreview: false,
    layout: 'custom',
    restrictInput: true, // Prevent keys not in the displayed keyboard from being typed in
    preventPaste: true,  // prevent ctrl-v and right click
    autoAccept: true,
    maxLength: 30,
    useCombos: false,
    customLayout: {
        'normal': [
            'q w e r t y u i o p',
            'a s d f g h j k l {bksp}',
            'z x c v b n m {s}',
            '{cancel} {space} {accept}'
        ],
        'shift': [
            'Q W E R T Y U I O P',
            'A S D F G H J K L {bksp}',
            'Z X C V B N M {s}',
            '{cancel} {space} {accept}'
        ]
    },
    css: {
        // input & preview
        input: 'form-control input-sm',
        // keyboard container
        container: 'center-block dropdown-menu', // jumbotron
        // default state
        buttonDefault: 'btn btn-default',
        // hovered button
        buttonHover: 'btn-primary',
        // Action keys (e.g. Accept, Cancel, Tab, etc);
        // this replaces "actionClass" option
        buttonAction: 'active',
        // used when disabling the decimal button {dec}
        // when a decimal exists in the input area
        buttonDisabled: 'disabled'
    }
});


$('.only-alpha-capital').keyboard({
    usePreview: false,
    layout: 'custom',
    restrictInput: true, // Prevent keys not in the displayed keyboard from being typed in
    preventPaste: true,  // prevent ctrl-v and right click
    autoAccept: true,
    maxLength: 30,
    useCombos: false,
    customLayout: {
        'normal': [
            'Q W E R T Y U I O P',
            'A S D F G H J K L {bksp}',
            'Z X C V B N M',
            '{cancel} {accept}'
        ]
    },
    css: {
        // input & preview
        input: 'form-control input-sm',
        // keyboard container
        container: 'center-block dropdown-menu', // jumbotron
        // default state
        buttonDefault: 'btn btn-default',
        // hovered button
        buttonHover: 'btn-primary',
        // Action keys (e.g. Accept, Cancel, Tab, etc);
        // this replaces "actionClass" option
        buttonAction: 'active',
        // used when disabling the decimal button {dec}
        // when a decimal exists in the input area
        buttonDisabled: 'disabled'
    }
});


$('.only-alpha-capital-space-allow').keyboard({
    usePreview: false,
    layout: 'custom',
    restrictInput: true, // Prevent keys not in the displayed keyboard from being typed in
    preventPaste: true,  // prevent ctrl-v and right click
    autoAccept: true,
    maxLength: 30,
    useCombos: false,
    customLayout: {
        'normal': [
            'Q W E R T Y U I O P',
            'A S D F G H J K L {bksp}',
            'Z X C V B N M',
            '{cancel} {space} {accept}'
        ]
    },
    css: {
        // input & preview
        input: 'form-control input-sm',
        // keyboard container
        container: 'center-block dropdown-menu', // jumbotron
        // default state
        buttonDefault: 'btn btn-default',
        // hovered button
        buttonHover: 'btn-primary',
        // Action keys (e.g. Accept, Cancel, Tab, etc);
        // this replaces "actionClass" option
        buttonAction: 'active',
        // used when disabling the decimal button {dec}
        // when a decimal exists in the input area
        buttonDisabled: 'disabled'
    }
});

$('.number').keyboard({
    usePreview: false,
    layout: 'custom',
    restrictInput: true, // Prevent keys not in the displayed keyboard from being typed in
    preventPaste: true,  // prevent ctrl-v and right click
    autoAccept: true,
    maxLength: 11,
    useCombos: false,
    customLayout: {
        'normal': [
            '7 8 9',
            '4 5 6',
            '1 2 3',
            '{clear} 0 {bksp}',
            '{cancel} {accept}'
        ]
    },
    css: {
        // input & preview
        input: 'form-control input-sm',
        // keyboard container
        container: 'center-block dropdown-menu', // jumbotron
        // default state
        buttonDefault: 'btn btn-default',
        // hovered button
        buttonHover: 'btn-primary',
        // Action keys (e.g. Accept, Cancel, Tab, etc);
        // this replaces "actionClass" option
        buttonAction: 'active',
        // used when disabling the decimal button {dec}
        // when a decimal exists in the input area
        buttonDisabled: 'disabled'
    }
});

$('.capital-alpha-numeric').keyboard({
    usePreview: false,
    layout: 'custom',
    restrictInput: true, // Prevent keys not in the displayed keyboard from being typed in
    preventPaste: true,  // prevent ctrl-v and right click
    autoAccept: true,
    maxLength: 30,
    useCombos: false,
    customLayout: {
        'normal': [
            '1 2 3 4 5 6 7 8 9 0',
            'Q W E R T Y U I O P',
            'A S D F G H J K L {bksp}',
            'Z X C V B N M ',
            '{cancel} {accept}'
        ]
    },
    css: {
        // input & preview
        input: 'form-control input-sm',
        // keyboard container
        container: 'center-block dropdown-menu', // jumbotron
        // default state
        buttonDefault: 'btn btn-default',
        // hovered button
        buttonHover: 'btn-primary',
        // Action keys (e.g. Accept, Cancel, Tab, etc);
        // this replaces "actionClass" option
        buttonAction: 'active',
        // used when disabling the decimal button {dec}
        // when a decimal exists in the input area
        buttonDisabled: 'disabled'
    }
});


