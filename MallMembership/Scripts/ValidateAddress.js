$("#createFormId").validate({
    rules: {
       Country: {
            required: true,
            maxlength: 100
        },
        State: {
            required: true

        },
        City: {
            required: true,
        }
    },
    messages: {
        Country: {
            required: "Please enter your Address",
            maxlength: "Required Limit is 100 words"
        },
        State: {
            required: "Please Enter your State"

        },
        City: {
            required: "Please Enter City",

        }
    }
});