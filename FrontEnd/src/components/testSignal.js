$(
    function(){
        //声明hub连接
        var bro = $.connection.brotherHub;
        bro.client.sayHiBro = function(msg){
            alert(msg);
        };
        $.connection.hub.start().done(function(){
            console.log(456);
            bro.server.hiBro("Code Man");

        })
        $.connection.hub.start(function(){
            console.log(123);
        })
        $.connection.hub.start().done(function () {
            hello.server.login($('#displayname').val());
            hello.server.notice();
            $('#sendmessage').click(function () {
                let user = $('#user').val()
                if (user.trim()=="") {
                    hello.server.send($('#displayname').val(), '', $('#message').val(), true);
                }
                else {
                    // Call the Send method on the hub.
                    hello.server.send($('#displayname').val(), $('#user').val(), $('#message').val(), false);
                }
                // Clear text box and reset focus for next comment.
                $('#message').val('').focus();
            });
        });
    }
)