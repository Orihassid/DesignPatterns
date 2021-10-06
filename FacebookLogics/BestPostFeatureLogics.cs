using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace FacebookLogics
{
    public static class BestPostFeatureLogics
    {
        public static Post GetMostPopulatedPost(List<Post> i_ListPosts, bool i_ByComments, bool i_ByLikes)
        {
            Post BestPost = null;
            if(i_ByComments && i_ByLikes)
            {
                BestPost = calculateByCommentsAndLikes(i_ListPosts);
            }
            else if(i_ByComments)
            {
                BestPost = calculateByComments(i_ListPosts);
            }
            else if(i_ByLikes)
            {
                BestPost = calculateByLikes(i_ListPosts);
            }

            return BestPost;
        }

        private static Post calculateByLikes(List<Post> i_ListPosts)
        {
            Post maximumPost = i_ListPosts[0];
            for(int i = 1; i < i_ListPosts.Count; i++)
            {
                if(maximumPost.LikedBy.Count < i_ListPosts[i].LikedBy.Count)
                {
                    maximumPost = i_ListPosts[i];
                }
            }

            return maximumPost;
        }

        private static Post calculateByComments(List<Post> i_ListPosts)
        {
            Post maximumPost = i_ListPosts[0];
            for (int i = 1; i < i_ListPosts.Count; i++)
            {
                if (maximumPost.Comments.Count < i_ListPosts[i].Comments.Count)
                {
                    maximumPost = i_ListPosts[i];
                }
            }

            return maximumPost;
        }

        private static Post calculateByCommentsAndLikes(List<Post> i_ListPosts)
        {
            Post maximumPost = i_ListPosts[0];
            for (int i = 1; i < i_ListPosts.Count; i++)
            {
                if (maximumPost.Comments.Count + maximumPost.LikedBy.Count < i_ListPosts[i].Comments.Count + i_ListPosts[i].LikedBy.Count)
                {
                    maximumPost = i_ListPosts[i];
                }
            }

            return maximumPost;
        }

        public static Photo GetMostPopulatedPhoto(List<Photo> i_UserPhotoList, bool i_CommentsChecked, bool i_LikesChecked)
        {
            Photo BestPhoto = null;
            if (i_CommentsChecked && i_LikesChecked)
            {
                BestPhoto = calculatePhotoByCommentsAndLikes(i_UserPhotoList);
            }
            else if (i_CommentsChecked)
            {
                BestPhoto = calculatePhotoByComments(i_UserPhotoList);
            }
            else if (i_LikesChecked)
            {
                BestPhoto = calculatePhotoByLikes(i_UserPhotoList);
            }

            return BestPhoto;
        }

        private static Photo calculatePhotoByCommentsAndLikes(List<Photo> i_UserPhotoList)
        {
            Photo bestPhoto = i_UserPhotoList[0];
            for (int i = 1; i < i_UserPhotoList.Count; i++)
            {
                if (bestPhoto.Comments.Count + bestPhoto.LikedBy.Count < i_UserPhotoList[i].Comments.Count + i_UserPhotoList[i].LikedBy.Count)
                {
                    bestPhoto = i_UserPhotoList[i];
                }
            }

            return bestPhoto;
        }

        private static Photo calculatePhotoByComments(List<Photo> i_UserPhotoList)
        {
            Photo bestPhoto = i_UserPhotoList[0];
            for (int i = 1; i < i_UserPhotoList.Count; i++)
            {
                if (bestPhoto.Comments.Count < i_UserPhotoList[i].Comments.Count)
                {
                    bestPhoto = i_UserPhotoList[i];
                }
            }

            return bestPhoto;
        }

        private static Photo calculatePhotoByLikes(List<Photo> i_UserPhotoList)
        {
            Photo bestPhoto = i_UserPhotoList[0];
            for (int i = 1; i < i_UserPhotoList.Count; i++)
            {
                if (bestPhoto.LikedBy.Count < i_UserPhotoList[i].LikedBy.Count)
                {
                    bestPhoto = i_UserPhotoList[i];
                }
            }

            return bestPhoto;
        }
    }
}