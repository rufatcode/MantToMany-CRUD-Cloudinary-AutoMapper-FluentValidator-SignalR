"use strict";






$(document).ready(function () {

    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
    connection.start();
    connection.on("OnConnect", function (userId) {
        let statusIcon = $(`#${userId}status>i`)
        statusIcon.next().html("online");
        statusIcon.removeClass("offline");
        statusIcon.addClass("online");
        console.log(userId + ":connect")
    })
    connection.on("OnDisConnect", function (userId) {
        let statusIcon = $(`#${userId}status>i`)
        statusIcon.next().html("offline");
        statusIcon.removeClass("online");
        statusIcon.addClass("offline");
        console.log(userId + ":disconnect")
    })
    connection.on("RecieveMessage", function (userId, message) {
        //console.log(userId.message);
        let li = `<li class="clearfix">
                                    <div class="message-data text-right">
                                        <span class="message-data-time">10:10 AM, Today</span>
                                        <img src="https://bootdey.com/img/Content/avatar/avatar7.png" alt="avatar">
                                    </div>
                                    <div class="message other-message float-right"> ${message} </div>
                                </li>`
        $(".usermessagesList").append(li)
    })

    let userId = $(".userNameHeadling").attr("data-id");

    $(".sendIcon").click(function () {
        let message = $(".messageInput").val();
        connection.invoke("SendMessage", userId, message);
    })

    $(".userslist>li").click(function () {
        const userId = $(this).attr("data-id");
        $(".userslist>li").removeClass("active");
        $(this).addClass("active");
        axios.get(`/Chat/Get/${userId}`).then(res => {
            console.log(res.data)
            $(".userNameHeadling").html(res.data.fullName);
        })
    })



});
