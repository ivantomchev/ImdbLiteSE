$(function () {

    $('.chzn-select').chosen();

    $('.chosen-choices').addClass('form-control');

    $('#selectedCharacters').chosen().change(function () {

        var characterList = $('#character-list');
        var parameters = [];
        var selectedCelebrities = $(this).chosen().val();

        if (selectedCelebrities != null) {

            var len = selectedCelebrities.length;

            for (var i = 0; i < len; i++) {

                var celebrityName = $(this).find('option[value="' + selectedCelebrities[i] + '"]').text();
                var celebrityId = selectedCelebrities[i];
                var characterName = $('input[celebrity="' + celebrityName + '"]').val();

                var current = {
                    celebrityName: celebrityName,
                    celebrityId: celebrityId,
                    characterName: characterName,
                };

                parameters.push(current);
            };
        };
        console.log(parameters);

        $.ajax({
            url: '/Administration/Movies/AddCharacters',
            type: 'Post',
            data: JSON.stringify(parameters),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                $(characterList).html(result);
            },
            error: function (request) {
                console.log('error');
            }
        });
    });
});

$(function () {

    var participationType = {
        "Director": 0,
        "Producer": 1
    };

    $('form').submit(function () {

        var choices = [];
        var selectedDirectors = $('#selectedDirectors').chosen().val();
        var selectedProducers = $('#selectedProducers').chosen().val();

        var container = $('#container');
        var castmembers = $('<div>');
        castmembers.attr('id', 'selected-castmembers');
        var hiddenElement = $('<input>');
        hiddenElement.attr('type', 'hidden');

        choices = AddSelectedCastMembers(selectedDirectors, choices, participationType.Director);
        choices = AddSelectedCastMembers(selectedProducers, choices, participationType.Producer);

        for (var i = 0; i < choices.length; i++) {

            var elementCelebrityData = hiddenElement.clone();
            elementCelebrityData.attr('name', 'CastMembers[' + i + '].CelebrityId');
            elementCelebrityData.attr('id', 'CastMembers_' + i + '__CelebrityId');
            elementCelebrityData.val(choices[i].CelebrityId);

            var elementParticipationData = hiddenElement.clone();
            elementParticipationData.attr('name', 'CastMembers[' + i + '].Participation');
            elementParticipationData.attr('id', 'CastMembers_' + i + '__Participation');
            elementParticipationData.val(choices[i].Participation);

            castmembers.append(elementCelebrityData);
            castmembers.append(elementParticipationData);
        };
        container.append(castmembers);
    });

    function AddSelectedCastMembers(selectedCastMembers, choices, participationType) {

        if (selectedCastMembers != null) {

            var len = selectedCastMembers.length;

            for (var i = 0; i < len; i++) {

                var current = {
                    "CelebrityId": selectedCastMembers[i],
                    "Participation": participationType
                };
                choices.push(current);
            };
        };
        return choices;
    };
});

//Client-side creation
//$(function () {

//    $(".chzn-select").chosen();

//    $('.chosen-choices').addClass('form-control');

//    $('#Characters').chosen().change(function () {

//        var characterList = $('#selected-characters');
//        characterList.children().remove();

//        var inputElement = $('<input>');
//        var labelElement = $('<label>');
//        var spanElement = $('<span>');
//        spanElement.addClass('field-validation-valid text-danger');
//        spanElement.attr('data-valmsg-replace', true);

//        var selectedCharacters = $(this).chosen().val();

//        if (selectedCharacters != null) {

//            characterList.parent().removeClass('hidden');

//            var len = selectedCharacters.length;

//            for (var i = 0; i < len; i++) {

//                var celebrityName = $(this).find('option[value="' + selectedCharacters[i] + '"]').text();

//                var elementCelebrityLabel = labelElement.clone();
//                elementCelebrityLabel.attr('for', 'Characters_' + i + '__CharacterName');
//                elementCelebrityLabel.addClass('control-label');
//                elementCelebrityLabel.text(celebrityName);

//                var elementCelebrityData = inputElement.clone();
//                elementCelebrityData.attr('type', 'hidden');
//                elementCelebrityData.attr('name', 'Characters[' + i + '].CelebrityId');
//                elementCelebrityData.attr('id', 'Characters_' + i + '__CelebrityId');
//                elementCelebrityData.val(selectedCharacters[i]);

//                var elementCelebrityName = inputElement.clone();
//                elementCelebrityName.attr('type', 'hidden');
//                elementCelebrityName.attr('name', 'Characters[' + i + '].CelebrityName');
//                elementCelebrityName.attr('id', 'Characters_' + i + '__CelebrityName');
//                elementCelebrityName.val(celebrityName);

//                var elementCharacterName = inputElement.clone();
//                elementCharacterName.addClass('form-control text-box single-line');
//                elementCharacterName.attr("name", "Characters[" + i + "].CharacterName");
//                elementCharacterName.attr("id", "Characters_" + i + "__CharacterName");

//                var elementValidation = spanElement.clone();
//                elementValidation.attr('data-valmsg-for', "Characters_" + i + "__CharacterName")

//                characterList.append(elementCelebrityLabel);
//                characterList.append(elementCelebrityData);
//                characterList.append(elementCelebrityName)
//                characterList.append(elementCharacterName);
//                characterList.append(elementValidation);
//            };
//        } else {
//            characterList.parent().addClass('hidden');
//        };
//    });
//});