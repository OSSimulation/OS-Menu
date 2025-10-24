// OS Menu v2 (Unity port), Thomasluigi07 2025
//
// Can you believe it? A reference to the Roblox (and HTML) version!
// This code is going to suck even more than the Roblox code, since
// I have barely used Unity myself. Oh well, it's a learning
// experience!
//
// As your reward for poking around in this source code, here's a
// thought from me as I'm developing this.
//
// What's the point of having messaging, parties and friends if this
// doesn't even have online connectivity? I did implement steamworks
// at one point but I removed it because I'm not bothered to maintain
// that. Might as well let users customise their own friendlist.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    private Text _title, _time, _username, _friends, _parties, _messages;
    [SerializeField]
    private Image _avatar;
    [SerializeField]
    public string title, username;
    [SerializeField]
    public byte friendsOnline, partyCount, newMessages;

    void Start()
    {
        _time.text = "23:00"; // Xbox 360 reference!
    }

    void Update()
    {
        _title.text = title;
        _time.text = System.DateTime.Now.ToString("HH:mm");
        _username.text = username;
        // The if else hell is back with a vengance from Roblox.
        if(friendsOnline == 0) {
            _friends.text = "";
        } else {
            _friends.text = friendsOnline.ToString();
        }
        if(partyCount == 0) {
            _parties.text = "";
        } else {
            _parties.text = partyCount.ToString();
        }
        if(newMessages == 0) {
            _messages.text = "";
        } else {
            _messages.text = newMessages.ToString();
        }
    }
}
