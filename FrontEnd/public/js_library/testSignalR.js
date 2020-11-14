$(
    function(){
        //声明hub连接
        var bro = $.connection.brotherHub;
        var hello = $.connection.helloHub;
        bro.client.sayHiBro = function(msg){
            alert(msg);
        };
        $.connection.hub.start().done(function(){
            debugger
            console.log(456);
            bro.server.hiBro("Code Man");
            $("#brother").click(function(){
                bro.server.hiBro("Code Man");
            });

        })
        $.connection.hub.start(function(){
            debugger
            console.log(123);
        }).done(function(){
            debugger
            bro.server.hiBro("Code Man")
        }).then(function(){
            bro.server.hiBro("Code Man")
        });
        $.connection.hub.start().done(function () {
            debugger
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
        
        $("#brother").click(function(){
            var bro = $.connection.brotherHub;
            bro.client.sayHiBro = function(msg){
                alert(msg);
            };
            $.connection.hub.start(function(){
                alert(1);
            }).done(function(){
                debugger
                console.log(456);
                bro.server.hiBro("Code Man");
                $("#brother").click(function(){
                    bro.server.hiBro("Code Man");
                });
    
            });
        });
    }
)