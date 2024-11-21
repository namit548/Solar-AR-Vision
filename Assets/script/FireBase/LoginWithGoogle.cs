//##Code 1 Explaination below at the down last
using System.Collections.Generic;
using Firebase.Extensions;
using Google;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Required for scene management
using UnityEngine.Networking;
using System.Collections;

public class LoginWithGoogle : MonoBehaviour
{
    public string GoogleAPI = "1031308617646-8bdqemcs3bmf1bae8tvk1d38d0tvie93.apps.googleusercontent.com";
    private GoogleSignInConfiguration configuration;

    private Firebase.Auth.FirebaseAuth auth;

    public TMP_Text Username, UserEmail;
    public GameObject LoginScreen, ProfileScreen;
    public Image UserProfilePic;
    public Button ContinueButton;

    public GameObject BackgroundImage; // Reference to the background image

    private void Awake()
    {
        configuration = new GoogleSignInConfiguration
        {
            WebClientId = GoogleAPI,
            RequestIdToken = true,
        };
    }

    private void Start()
    {
        InitFirebase();

        // Initially disable the button, profile picture, and background image until login is successful
        ContinueButton.gameObject.SetActive(false);
        UserProfilePic.gameObject.SetActive(false);
        BackgroundImage.SetActive(false); // Hide background image at start

        ContinueButton.onClick.AddListener(ChangeScene);  // Assign the button to change the scene
    }

    void InitFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    public void Login()
    {
        GoogleSignIn.Configuration = new GoogleSignInConfiguration
        {
            WebClientId = GoogleAPI,  // Client ID from Firebase Console (Web Client ID)
            RequestIdToken = true,
        };
        GoogleSignIn.Configuration.RequestEmail = true;

        Task<GoogleSignInUser> signIn = GoogleSignIn.DefaultInstance.SignIn();

        signIn.ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.Log("Sign-in was canceled.");
            }
            else if (task.IsFaulted)
            {
                Debug.LogError("Sign-in encountered an error: " + task.Exception);
            }
            else
            {
                Debug.Log("Sign-in successful.");
                GoogleSignInUser googleUser = task.Result; // Get the Google user
                Credential credential = Firebase.Auth.GoogleAuthProvider.GetCredential(googleUser.IdToken, null);
                auth.SignInWithCredentialAsync(credential).ContinueWith(authTask =>
                {
                    if (authTask.IsCanceled)
                    {
                        Debug.Log("Firebase Authentication was canceled.");
                    }
                    else if (authTask.IsFaulted)
                    {
                        Debug.LogError("Firebase Authentication encountered an error: " + authTask.Exception);
                    }
                    else
                    {
                        FirebaseUser user = authTask.Result; // Get the Firebase user
                        Debug.Log("User signed in successfully: " + user.DisplayName);

                        // Update UI in a coroutine to ensure graphics device is ready
                        StartCoroutine(UpdateUIAfterLogin(user));
                    }
                });
            }
        });
    }

    private IEnumerator UpdateUIAfterLogin(FirebaseUser user)
    {
        yield return null; // Wait for a frame to ensure everything is initialized

        // Update UI
        Username.text = user.DisplayName;
        UserEmail.text = user.Email;

        // Fetch and display profile picture
        StartCoroutine(LoadProfilePicture(user.PhotoUrl.ToString()));

        // Hide login screen and show profile screen
        LoginScreen.SetActive(false);
        ProfileScreen.SetActive(true);

        // Enable the button, profile picture, and background image after login is successful
        ContinueButton.gameObject.SetActive(true);
        UserProfilePic.gameObject.SetActive(true);
        BackgroundImage.SetActive(true);  // Show the background image
    }

    // Function to change the scene
    void ChangeScene()
    {
        SceneManager.LoadScene("StartingScreen");  // Replace with the actual scene name
    }

    IEnumerator LoadProfilePicture(string imageUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error downloading profile picture: " + request.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            UserProfilePic.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
    }
}










//using System.Collections;
//using System.Collections.Generic;
//using Firebase.Extensions;
//using Google;
//using System.Threading.Tasks;
//using UnityEngine;
//using TMPro;
//using Firebase.Auth;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;  // Required for scene management
//using UnityEngine.Networking;
//public class LoginWithGoogle : MonoBehaviour
//{
//    public string GoogleAPI = "1031308617646-8bdqemcs3bmf1bae8tvk1d38d0tvie93.apps.googleusercontent.com";
//    private GoogleSignInConfiguration configuration;

//    Firebase.Auth.FirebaseAuth auth;
//    Firebase.Auth.FirebaseUser user;

//    public TMP_Text Username, UserEmail;
//    public GameObject LoginScreen, ProfileScreen;
//    public Image UserProfilePic;

//    public Button ContinueButton; // Reference to the button for changing the scene

//    private void Awake()
//    {
//        configuration = new GoogleSignInConfiguration
//        {
//            WebClientId = GoogleAPI,
//            RequestIdToken = true,
//        };
//    }

//    private void Start()
//    {
//        InitFirebase();

//        // Initially disable the button until login is successful
//        ContinueButton.gameObject.SetActive(false);
//        ContinueButton.onClick.AddListener(ChangeScene);  // Assign the button to change the scene
//    }

//    void InitFirebase()
//    {
//        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
//    }

//    public void Login()
//    {
//        GoogleSignIn.Configuration = new GoogleSignInConfiguration
//        {
//            WebClientId = GoogleAPI,  // Client ID from Firebase Console (Web Client ID)
//            RequestIdToken = true,
//        };
//        GoogleSignIn.Configuration.RequestEmail = true;

//        Task<GoogleSignInUser> signIn = GoogleSignIn.DefaultInstance.SignIn();

//        TaskCompletionSource<FirebaseUser> signInCompleted = new TaskCompletionSource<FirebaseUser>();
//        signIn.ContinueWith(task => {
//            if (task.IsCanceled)
//            {
//                signInCompleted.SetCanceled();
//                Debug.Log("Sign-in was canceled.");
//            }
//            else if (task.IsFaulted)
//            {
//                signInCompleted.SetException(task.Exception);
//                Debug.LogError("Sign-in encountered an error: " + task.Exception);
//            }
//            else
//            {
//                Debug.Log("Sign-in successful.");
//                Credential credential = Firebase.Auth.GoogleAuthProvider.GetCredential(((Task<GoogleSignInUser>)task).Result.IdToken, null);
//                auth.SignInWithCredentialAsync(credential).ContinueWith(authTask => {
//                    if (authTask.IsCanceled)
//                    {
//                        signInCompleted.SetCanceled();
//                        Debug.Log("Firebase Authentication was canceled.");
//                    }
//                    else if (authTask.IsFaulted)
//                    {
//                        signInCompleted.SetException(authTask.Exception);
//                        Debug.LogError("Firebase Authentication encountered an error: " + authTask.Exception);
//                    }
//                    else
//                    {
//                        FirebaseUser user = ((Task<FirebaseUser>)authTask).Result;
//                        Debug.Log("User signed in successfully: " + user.DisplayName);

//                        // Update UI
//                        Username.text = user.DisplayName;
//                        UserEmail.text = user.Email;

//                        // Fetch and display profile picture
//                        StartCoroutine(LoadProfilePicture(user.PhotoUrl.ToString()));

//                        // Optionally hide login screen and show profile screen
//                        LoginScreen.SetActive(false);
//                        ProfileScreen.SetActive(true);

//                        // Enable the button after login is successful
//                        ContinueButton.gameObject.SetActive(true);
//                    }
//                });
//            }
//        });
//    }

//    // Function to change the scene
//    void ChangeScene()
//    {
//        SceneManager.LoadScene("StartingScreen");  // Replace with the actual scene name
//    }
//    IEnumerator LoadProfilePicture(string imageUrl)
//    {
//        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);
//        yield return request.SendWebRequest();

//        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
//        {
//            Debug.LogError("Error downloading profile picture: " + request.error);
//        }
//        else
//        {
//            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
//            UserProfilePic.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
//        }
//    }
//}












//////##Code 1 explaination
////using System.Collections.Generic;           // Provides generic collections like lists, dictionaries, etc.
////using Firebase.Extensions;                  // Firebase extensions for handling async tasks in Unity
////using Google;                               // Google library for handling Google Sign-In
////using System.Threading.Tasks;               // Allows the use of tasks for asynchronous programming
////using UnityEngine;                          // Unity's core namespace for basic functionality
////using TMPro;                                // TextMesh Pro for high-quality text rendering
////using Firebase.Auth;                        // Firebase namespace for authentication
////using UnityEngine.UI;                       // Unity UI elements like Button, Image, etc.
////using UnityEngine.SceneManagement;          // Required for scene management
////using UnityEngine.Networking;               // Used for downloading data (e.g., profile picture) from the web
////using System.Collections;                   // Basic namespace for collections and coroutines

////public class LoginWithGoogle : MonoBehaviour
////{
////    public string GoogleAPI = "1031308617646-8bdqemcs3bmf1bae8tvk1d38d0tvie93.apps.googleusercontent.com";  // Google Web Client ID from Firebase console
////    private GoogleSignInConfiguration configuration;     // Stores Google Sign-In configuration settings

////    private Firebase.Auth.FirebaseAuth auth;             //create variable auth and let user use firebase tools for login and logout

////    public TMP_Text Username, UserEmail;                 // Text fields for displaying username and email
////    public GameObject LoginScreen, ProfileScreen;        // Screens for login and profile views
////    public Image UserProfilePic;                         // Image element to show user profile picture
////    public Button ContinueButton;                        // Button for continuing to another screen

////    public GameObject BackgroundImage;                   // Reference to the background image

////    private void Awake()
////    {
////        Configure Google Sign - In with Web Client ID and request an ID token
////       configuration = new GoogleSignInConfiguration
////       {
////           WebClientId = GoogleAPI,//use to connect app to google to identified the app
////           RequestIdToken = true,//This tells Google to give you an ID token after sign-in, which Firebase will use to confirm that the user has successfully signed in with Google.
////       };
////    }

////    private void Start()
////    {
////        InitFirebase();  // Initialize Firebase authentication

////        Disable button, profile picture, and background image initially(before successful login)
////        ContinueButton.gameObject.SetActive(false);
////        UserProfilePic.gameObject.SetActive(false);
////        BackgroundImage.SetActive(false);              // Hide background image at start

////        Add a listener to the Continue button to call ChangeScene when clicked
////        ContinueButton.onClick.AddListener(ChangeScene);
////    }

////    Initializes Firebase Authentication instance
////    void InitFirebase()//sets up Firebase Authentication.
////    {
////        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;  // Gets the default Firebase auth instance
////    }

////    Called when Login button is pressed to initiate Google Sign-In
////    public void Login()
////    {
////        Configure Google Sign - In with Web Client ID and request email
////        GoogleSignIn.Configuration = new GoogleSignInConfiguration
////        {
////            WebClientId = GoogleAPI,                     // Firebase Web Client ID
////            RequestIdToken = true,                       // Request an ID token for Firebase auth//use firebase that token to check login succesfully and veri
////        };
////        GoogleSignIn.Configuration.RequestEmail = true;  // Request email information from Google

////        Begin the Google sign-in process
////        Task<GoogleSignInUser> signIn = GoogleSignIn.DefaultInstance.SignIn();

////        Handle the result of the sign-in attempt
////        signIn.ContinueWith(task =>
////        {
////            if (task.IsCanceled)                         // If sign-in is canceled
////            {
////                Debug.Log("Sign-in was canceled.");
////            }
////            else if (task.IsFaulted)                     // If there is an error during sign-in
////            {
////                Debug.LogError("Sign-in encountered an error: " + task.Exception);
////            }
////            else                                         // If sign-in is successful
////            {
////                Debug.Log("Sign-in successful.");
////                GoogleSignInUser googleUser = task.Result;  // Get the Google user information

////                Use Google credentials to sign into Firebase
////               Credential credential = Firebase.Auth.GoogleAuthProvider.GetCredential(googleUser.IdToken, null);
////                auth.SignInWithCredentialAsync(credential).ContinueWith(authTask =>
////                {
////                    if (authTask.IsCanceled)            // If Firebase authentication is canceled
////                    {
////                        Debug.Log("Firebase Authentication was canceled.");
////                    }
////                    else if (authTask.IsFaulted)        // If there is an error during Firebase authentication
////                    {
////                        Debug.LogError("Firebase Authentication encountered an error: " + authTask.Exception);
////                    }
////                    else                                // If Firebase authentication is successful
////                    {
////                        FirebaseUser user = authTask.Result;   // Retrieve the Firebase user data
////                        Debug.Log("User signed in successfully: " + user.DisplayName);

////                        Update the UI with user info after successful login
////                        StartCoroutine(UpdateUIAfterLogin(user));
////                    }
////                });
////            }
////        });
////    }

////    Coroutine to update the UI with user information after successful login
////    private IEnumerator UpdateUIAfterLogin(FirebaseUser user)
////    {
////        yield return null;                                // Wait for a frame to ensure all UI elements are ready

////        Display user’s name and email on the profile screen
////        Username.text = user.DisplayName;
////        UserEmail.text = user.Email;

////        Start loading and displaying the user’s profile picture
////        StartCoroutine(LoadProfilePicture(user.PhotoUrl.ToString()));

////        Hide login screen and show profile screen
////        LoginScreen.SetActive(false);
////        ProfileScreen.SetActive(true);

////        Enable the continue button, profile picture, and background image after login
////        ContinueButton.gameObject.SetActive(true);
////        UserProfilePic.gameObject.SetActive(true);
////        BackgroundImage.SetActive(true);                  // Display background image
////    }

////    Method to load a new scene when the continue button is clicked
////    void ChangeScene()
////    {
////        SceneManager.LoadScene("StartingScreen");         // Load the specified scene (replace with actual scene name)
////    }

////    Coroutine to download and set the user’s profile picture
////   IEnumerator LoadProfilePicture(string imageUrl)
////    {
////        UnityWebRequest request = UnityWebRequestTexture.GetTexture(imageUrl);  // Send a request to download the image
////        yield return request.SendWebRequest();                                  // Wait for the download to complete

////        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
////        {
////            Debug.LogError("Error downloading profile picture: " + request.error);  // Log errors if the download fails
////        }
////        else
////        {
////            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;  // Retrieve downloaded texture
////            UserProfilePic.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));  // Set the profile picture
////        }
////    }
////}
