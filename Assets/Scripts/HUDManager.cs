// OS Menu v2 (Unity port), Thomasluigi07 2025
//
// Can you believe it? A reference to the Roblox (and HTML) version!
// This code is going to suck even more than the Roblox code, since
// I have barely used Unity myself. Oh well, it's a learning
// experience!
//
// As your reward for poking around in this source code, here's some
// thoughts from me as I'm developing this.
//
// What's the point of having messaging, parties and friends if this
// doesn't even have online connectivity? I did implement steamworks
// at one point but I removed it because I'm not bothered to maintain
// that. Might as well let users customise their own friendlist.
//
// Also, Quick Launch is basically useless unless we make one
// project that has all of our projects built-in.
// ...that might be a cool idea, and solves the connectivity problem...
// I really need to figure out Unity though. I haven't even added the
// ability to change pages, which was in the Roblox version from the
// first release! If only I could focus on this like how I did with
// Windows XP Gui Test...

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField]
    private Text _debug, _title, _time, _username, _friends, _parties, _messages;
    [SerializeField]
    private Image _avatar;
    [SerializeField]
    private GameObject _currentPage,_selectedObject;
    [SerializeField]
    public bool enableDebugInfo;
    [SerializeField]
    public string pageTitle, username;
    [SerializeField]
    public byte friendsOnline, partyCount, newMessages;

    // DEBUG variables, only used when DEBUG is enabled
    int fps = 9001; // WinXP badge reference
    int visiblePages = 1; // TODO: Scan through all visible pages.
    string arch = "32 bit";
    string platform = "?";
    string version = "?";
    string currentPage = "?";
    string language = "en_AU"; // TODO: Implement LocalizationManager or whatever it was called in the Roblox version.
    string selectedObject = "?";

    void Start()
    {
        _time.text = "23:00"; // Xbox 360 reference!
        _debug.text = "";
        // We don't need to check for architecture EVERY update. Shoutout to me doing that in the Roblox version.
        if(Environment.Is64BitProcess) {
            arch = "64 bit";
        }
        platform = Application.platform.ToString(); // Ditto. Also put the ToString here so we don't have to call it every update.
        version = Application.version;
    }

    void Update()
    {
        _title.text = pageTitle;
        _time.text = System.DateTime.Now.ToString("HH:mm");
        _username.text = username;
        // The if else hell is back with a vengance from Roblox... nevermind.
        // HomePage/CommunityPage stuff
        _friends.text = "";
        _parties.text = "";
        _messages.text = "";
        if(friendsOnline > 0) {
            _friends.text = friendsOnline.ToString();
        }
        if(partyCount > 0) {
            _parties.text = partyCount.ToString();
        }
        if(newMessages > 0) {
            _messages.text = newMessages.ToString();
        }
        // DEBUG stuff
        _debug.text = "";
        if(enableDebugInfo) {
            // Prevent errors
            currentPage = "None";
            if (_currentPage != null) {
                currentPage = _currentPage.name;
            }
            selectedObject = "None";
            if (_selectedObject != null) {
                selectedObject = _selectedObject.name;
            }

            fps = (int)(1f / Time.unscaledDeltaTime);
            _debug.text = "FPS: "+fps.ToString()+" | LANGUAGE: "+language+" | ARCH: "+arch+" | PLATFORM: "+platform+" | VERSION: "+version+"\nVISIBLE PAGES: "+visiblePages+" | CURRENT PAGE: "+currentPage+" | SELECTED OBJECT: "+selectedObject;
        }
    }
}
